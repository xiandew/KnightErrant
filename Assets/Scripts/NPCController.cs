using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// Ref: https://www.youtube.com/watch?v=RXB7wKSoupI
public class NPCController : MonoBehaviour
{
    public float safeDistance;
    public RuntimeAnimatorController runController;
    public RuntimeAnimatorController walkController;
    public NPCWeaponController npcWeaponController;
    public NavMeshAgent navMeshAgent;
    public float maxTimeForNewPath;
    private bool inCoRoutine;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        if (Vector3.Distance(transform.position, player.transform.position) <= safeDistance) {
            // chase the player
            navMeshAgent.speed = 5f;
            animator.runtimeAnimatorController = runController;
            if (!inCoRoutine) {
                StartCoroutine(runAndAttack());
            }
        } else {
            // wander
            navMeshAgent.speed = 2f;
            animator.runtimeAnimatorController = walkController;
            if (!inCoRoutine) {
                StartCoroutine(wander());
            }
        }
    }

    private IEnumerator runAndAttack() {
        inCoRoutine = true;
        yield return new WaitForSeconds(Random.Range(2, maxTimeForNewPath));
        gameObject.transform.LookAt(player.transform);
        npcWeaponController.Shoot(player.transform.position);
        navMeshAgent.SetDestination(player.transform.position);
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
        Destroy(this.gameObject);
    }
}
