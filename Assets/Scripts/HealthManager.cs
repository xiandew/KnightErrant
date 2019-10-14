using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int initHealth;
    private int currHealth;
    private RectTransform currHealthRect;
    private float healthBarWidth;
    private float healthBarHeight;

    void Start() {
        currHealth = initHealth;
        if (gameObject.tag == "Enemy") {
            currHealthRect = transform.Find("HealthCanvas").Find("CurrentHealth").GetComponent<RectTransform>();
            healthBarWidth = currHealthRect.sizeDelta.x;
            healthBarHeight = currHealthRect.sizeDelta.y;
        }
    }

    public void ApplyDamage(int damage) {
        currHealth -= damage;
        if (gameObject.tag == "Enemy") {
            
            float widthOffset = (1 - ((float)currHealth / initHealth)) * healthBarWidth;

            currHealthRect.transform.localPosition = new Vector3(-widthOffset / 2, 0, 0);
            currHealthRect.sizeDelta = new Vector2(healthBarWidth - widthOffset, healthBarHeight);

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

}