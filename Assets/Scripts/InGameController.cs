using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    public SwarmManager swarmManager;
    
    // Start is called before the first frame update
    void Start()
    {
        swarmManager.GenerateSwarm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
