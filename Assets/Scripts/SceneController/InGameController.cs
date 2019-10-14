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

    private HealthManager playerHealthManager;
    
    // Start is called before the first frame update
    void Start()
    {
        swarmManager.GenerateSwarm();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = "" + playerHealthManager.GetCurrHealth();
    }

    public void GameOver()
    {
        InGameController.lastGameWon = false;
        SceneManager.LoadScene("GameEnded");
    }

    public void PlayerWon()
    {
        InGameController.lastGameWon = true;
        SceneManager.LoadScene("GameEnded");
    }
}
