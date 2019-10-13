using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int initHealth;

    private int currHealth;

    void start() {
        currHealth = initHealth;
    }

    public void ApplyDamage(int damage) {
        currHealth -= damage;
        if (currHealth <= 0) {
            (gameObject.GetComponent<NPCController>() ?. gameObject.GetComponent<PlayerController>()).Die();
        }
    }

}