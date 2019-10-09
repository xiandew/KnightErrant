using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int initHealth;

    private int currHealth;
    public void ApplyDamage(int damage) {
        currHealth -= damage;
    }

}