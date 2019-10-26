using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionController : MonoBehaviour
{

    public Text gameInstruction;
    public GameObject tutorialEndPrompt;

    private int currentInstr;
    private ArrayList instructions;
    
    // Start is called before the first frame update
    void Start()
    {
        tutorialEndPrompt.SetActive(false);

        instructions = new ArrayList();
        instructions.Add("Welcome to the world of Knight Errant");
        instructions.Add("Press W and S to move forward and backward");
        instructions.Add("Press A and D to move left and right");
        instructions.Add("Moving your mouse to look around");
        instructions.Add("Press SPACE to jump");
        instructions.Add("Click left mouse button to fire");
        currentInstr = 0;

        gameInstruction.text = instructions[currentInstr].ToString();
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            currentInstr++;

            if (currentInstr < instructions.Count) {
                gameInstruction.text = instructions[currentInstr].ToString();
            } 
            else {
                tutorialEndPrompt.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void StartNewGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void BackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
