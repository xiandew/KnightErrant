using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScreensController : MonoBehaviour {

    public Text resultText;

    void Start()
    {
        // Display text based on last game result
        if (InGameController.lastGameWon)
        {
            this.resultText.text = "Congrats!!! You Won The Game!";
        }
        else
        {
            this.resultText.text = "Sorry, You Lost!";
        }
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
