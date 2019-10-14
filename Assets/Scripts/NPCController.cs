using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// Ref: https://www.youtube.com/watch?v=RXB7wKSoupI
public class NPCController : MonoBehaviour
{
    public float safeDistance;
    public RuntimeAnimatorController walkController;
    public RuntimeAnimatorController runController;
    public NPCWeaponController npcWeaponController;
    public NavMeshAgent navMeshAgent;
    public float maxTimeForNewPath;
    public GameObject bloodSplashPrefab;
    private bool inCoRoutine;
    private GameObject player;
    private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("HealthCanvas").LookAt(
            transform.position + playerCamera.transform.rotation * Vector3.back, playerCamera.transform.rotation * Vector3.down);

        Animator anim = gameObject.GetComponent<Animator>();
        if (Vector3.Distance(transform.position, player.transform.position) <= safeDistance && GetComponent<Renderer>().isVisible) {
            // chase the player
            navMeshAgent.speed = 5f;
            anim.runtimeAnimatorController = runController;
            if (!inCoRoutine) {
                StartCoroutine(runAndAttack());
            }
        } else {
            // wander
            navMeshAgent.speed = 2f;
            anim.runtimeAnimatorController = walkController;
            if (!inCoRoutine) {
                StartCoroutine(wander());
            }
        }
    }

    private IEnumerator runAndAttack() {
        inCoRoutine = true;
        yield return new WaitForSeconds(Random.Range(2, maxTimeForNewPath));
        navMeshAgent.SetDestination(player.transform.position);

        gameObject.GetComponent<Animator>().SetTrigger("attack");
        yield return new WaitForSeconds(1);
        npcWeaponController.Shoot(player);

        inCoRoutine = false;
    }

    private IEnumerator wander() {
        inCoRoutine = true;
        yield return new WaitForSeconds(Random.Range(2, maxTimeForNewPath));
        navMeshAgent.SetDestination(getRandomPosition());
        inCoRoutine = false;
    }

    private Vector3 getRandomPosition() {
        return transform.position + new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
    }

    public void Die() {
        GameObject bloodSplash = Instantiate(bloodSplashPrefab);
        bloodSplash.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }
}
