using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SwarmManager : MonoBehaviour {

    // External parameters/variables
    public Terrain gameMap;
    public GameObject enemyTemplate;
    public int maxEnemyPerArea;
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
        if (this.transform.childCount <= 0 && !this.swarmDestroyed) {
            this.swarmDestroyedEvent.Invoke();
            this.swarmDestroyed = true;
        }
	}

    // Method to automatically generate swarm of enemies based on the set public attributes
    public void GenerateSwarm() {

        foreach (Transform subarea in gameMap.transform) {
            // Create swarm of enemies in a grid formation
            for (int i = 0; i < maxEnemyPerArea; i++) {
                    GameObject enemy = GameObject.Instantiate<GameObject>(enemyTemplate, subarea.transform.position, Quaternion.identity);
                    enemy.AddComponent<MeshRenderer>();
                    enemy.transform.parent = this.transform;
            }
        }
        this.swarmDestroyed = false;
    }
}
