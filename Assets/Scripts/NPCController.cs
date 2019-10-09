using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Ref: https://www.youtube.com/watch?v=RXB7wKSoupI
public class NPCController : MonoBehaviour
{
    public float safeDistance;
    public NavMeshAgent navMeshAgent;
    public float timeForNewPath;
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
        if (Vector3.Distance(transform.position, player.transform.position) <= safeDistance) {
            if (!inCoRoutine) {
                StartCoroutine(DoSomething());
            }
        }
    }

    IEnumerator DoSomething() {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        inCoRoutine = false;
    }

    void GetNewPath() {
        navMeshAgent.SetDestination(player.transform.position);
    }
}
