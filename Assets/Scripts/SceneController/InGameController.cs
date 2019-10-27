using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{

    public static bool lastGameWon;
    public SwarmManager swarmManager;
    public Text playerHealth;

    public Slider healthBarSlider;

    private HealthManager playerHealthManager;
    
    // Start is called before the first frame update
    void Start()
    {
        swarmManager.GenerateSwarm();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
        healthBarSlider.maxValue = playerHealthManager.initHealth;
    }

    // Update is called once per frame
    void Update()
    {
        int currHealth = playerHealthManager.GetCurrHealth();
        if (currHealth > healthBarSlider.maxValue) {
            healthBarSlider.maxValue = currHealth;
        }
        healthBarSlider.value = currHealth;
        playerHealth.text = "Your Health: " + playerHealthManager.GetCurrHealth();
    }

    public static void GameOver()
    {
        InGameController.lastGameWon = false;
        SceneManager.LoadScene("GameEnded");
    }

    public static void PlayerWon()
    {
        InGameController.lastGameWon = true;
        SceneManager.LoadScene("GameEnded");
    }
}
