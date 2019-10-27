using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionController : MonoBehaviour
{

    public Text gameInstruction;
    public GameObject tutorialEndPrompt;
    public SwarmManager npcManager;

    private int currentInstr;
    private ArrayList instructions;
    
    // Start is called before the first frame update
    void Start()
    {
        tutorialEndPrompt.SetActive(false);
        npcManager.gameObject.SetActive(false);

        instructions = new ArrayList();
        instructions.Add("Welcome to the world of Knight Errant\nPress ENTER to continue");
        instructions.Add("Press W and S to move forward and backward");
        instructions.Add("Press A and D to move left and right");
        instructions.Add("Moving your mouse to look around");
        instructions.Add("Press SPACE to jump");
        instructions.Add("Click left mouse button to fire");
        instructions.Add("Now, let's try to fight with an enemy");
        currentInstr = 0;

        gameInstruction.text = instructions[currentInstr].ToString();
     }

    // Update is called once per frame
    void Update()
    {
        HandleInstructions();
    }

    void HandleInstructions() {
        switch(currentInstr) {
            case 0:
                if (Input.GetKeyDown(KeyCode.Return)) {
                    currentInstr++;
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) {
                    currentInstr++;
                }   
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                    currentInstr++;
                }   
                break;
            case 3:
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");
                    if (mouseX != 0 || mouseY != 0) {
                        currentInstr++;
                    }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.Space)) {
                    currentInstr++;
                }   
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    npcManager.gameObject.SetActive(true);
                    currentInstr++;
                }
                break;
            case 6:
                if (npcManager.swarmDestroyed) {
                    currentInstr++;
                }
                break;
            default:
                break;
        }

        if (currentInstr < instructions.Count) {
            gameInstruction.text = instructions[currentInstr].ToString();
        }
        else {
            Cursor.lockState = CursorLockMode.None;
            tutorialEndPrompt.SetActive(true);
            gameInstruction.gameObject.SetActive(false);
        }

    }

    public void StartNewGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void BackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
