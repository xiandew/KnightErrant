using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SwarmManager : MonoBehaviour {

    // External parameters/variables
    public Terrain land;
    public GameObject enemyTemplate;
    public int enemyNum;
    public UnityEvent swarmDestroyedEvent;
    public bool swarmDestroyed = true;
    
	// Use this for initialization
	void Start () {
        // Initial parameters
        this.transform.localPosition = Vector3.left;
	}
	
	// Update is called once per frame
	void Update () {

        // Check if swarm destroyed, and trigger event if so
        if (this.transform.childCount <= 0 && !this.swarmDestroyed)
        {
            this.swarmDestroyedEvent.Invoke();
            this.swarmDestroyed = true;
        }
	}

    // Method to automatically generate swarm of enemies based on the set public attributes
    public void GenerateSwarm()
    {
        Vector3 min = land.terrainData.bounds.min;
        Vector3 max = land.terrainData.bounds.max;
        // Create swarm of enemies in a grid formation
        for (int i = 0; i < enemyNum; i++)
        {
                GameObject enemy = GameObject.Instantiate<GameObject>(enemyTemplate);
                float x = Random.Range(min.x, max.x);
                float z = Random.Range(min.z, max.z);

                enemy.transform.parent = this.transform;
                enemy.transform.position = new Vector3(x, Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)), z);
        }
        this.swarmDestroyed = false;
    }
}
