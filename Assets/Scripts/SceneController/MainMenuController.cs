using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {



    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    
    public void OpenInstructions()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }
}
