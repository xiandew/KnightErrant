using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

  
    public int initHealth;
    private int currHealth;
    private Slider healthSlider;



    void Start() {
        currHealth = initHealth;
        if (gameObject.tag == "Enemy") {
            healthSlider = transform.Find("HealthCanvas").Find("HealthBar").GetComponent<Slider>();
        }
    }

    public void ApplyDamage(int damage) {
        currHealth -= damage;
        if (gameObject.tag == "Enemy") {
            
            healthSlider.value = ((float)currHealth) / initHealth;

            if (currHealth <= 0) {
                gameObject.GetComponent<NPCController>().Die();
            }
        }
        if (gameObject.tag == "Player") {
            if (currHealth <= 0) {
                gameObject.GetComponent<PlayerController>().Lose();
            }
        }
    }

    public int GetCurrHealth() {
        return currHealth;
    }

    public void SetCurrHealth(int currHealth) {
        this.currHealth = currHealth;
    }
}