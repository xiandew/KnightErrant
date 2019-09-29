using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float timerForNewPath;
    private bool inCoRoutine;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCoRoutine) {
            StartCoroutine(DoSomething());
        }
    }

    Vector3 GetNewRandomPosition() {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator DoSomething() {
        inCoRoutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        inCoRoutine = false;
    }

    void GetNewPath() {
        navMeshAgent.SetDestination(this.GetNewRandomPosition());
    }
}
