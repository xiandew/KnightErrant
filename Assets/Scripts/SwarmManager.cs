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
        Bounds landBounds = land.terrainData.bounds;
        float y = landBounds.size.y / 2 + land.transform.localPosition.y;
        // Create swarm of enemies in a grid formation
        for (int i = 0; i < enemyNum; i++)
        {
                GameObject enemy = GameObject.Instantiate<GameObject>(enemyTemplate);
                float x = Random.Range(land.terrainData.size.x, land.transform.position.x + land.terrainData.size.x);
                float z = Random.Range(land.transform.position.z, land.transform.position.z + land.terrainData.size.z);

                enemy.transform.parent = this.transform;
                enemy.transform.position = new Vector3(x, Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)), z);
        }
        this.swarmDestroyed = false;
    }
}
