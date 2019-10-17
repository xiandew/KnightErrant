using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider difficultySlider;
    public Slider volumeSlider;
    public AudioSource audioSource;

    public void Start()
    {
        // Important: Make sure slider corresponds to underlying value
        // if it has been changed with scene invocations in-between
        difficultySlider.value = GlobalOptions.difficulty;

        volumeSlider.value = GlobalOptions.volume;

        DontDestroyOnLoad(this.gameObject);
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DifficultySliderChanged()
    {
        GlobalOptions.difficulty = difficultySlider.value;
    }

    public void VolumeSliderChanged() {
        audioSource.volume = GlobalOptions.volume = volumeSlider.value;
    }
}
