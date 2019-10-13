using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider difficultySlider;

    public void Start()
    {
        // Important: Make sure slider corresponds to underlying value
        // if it has been changed with scene invocations in-between
        difficultySlider.value = GlobalOptions.difficulty;
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DifficultySliderChanged()
    {
        GlobalOptions.difficulty = difficultySlider.value;
    }
}
