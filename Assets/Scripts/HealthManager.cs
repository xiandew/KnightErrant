using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int initHealth;

    private int currHealth;

    void Start() {
        currHealth = initHealth;
    }

    public void ApplyDamage(int damage) {
        currHealth -= damage;
        if (currHealth <= 0) {
            if (gameObject.tag == "Enemy") {
                gameObject.GetComponent<NPCController>().Die();
            }
            if (gameObject.tag == "Player") {
                gameObject.GetComponent<PlayerController>().Lose();
            }
        }
    }

    public int GetCurrHealth() {
        return currHealth;
    }

}