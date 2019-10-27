using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {


    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    
    public void OpenTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }
}
