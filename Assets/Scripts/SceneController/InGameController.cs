using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour
{

    public static bool lastGameWon;
    public SwarmManager swarmManager;
    
    // Start is called before the first frame update
    void Start()
    {
        swarmManager.GenerateSwarm();
    }

    // Update is called once per frame
    void Update()
    {
        
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
