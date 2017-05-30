// This script handles the function of the menu screen
// It holds variables that can be changed inside the unity editor
// and activates/deactives the layers based on the player's inputs
// The layers are the separate screens i.e the instruction and exit windows
// The buttons are also held as variables and upon clicking, they 
// execute a function such as starting the game or showing the instructions

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {
    // Variables to hold the quit screen popup and its buttons
    public Canvas quitMenu;
    public Button startButton;
    public Button exitButton;

    // Instruction pop up and its buttons
    public Canvas instruction;
    public Button showInstruction;
    public Button leaveInstruction;

	// Use this for initialization
    // Obtain and store components and then disable the instruction and quit menus so that they don't appear
	void Start () 
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        instruction = instruction.GetComponent<Canvas>();
        leaveInstruction = leaveInstruction.GetComponent<Button>();
        showInstruction = showInstruction.GetComponent<Button>();

        instruction.enabled = false;
        quitMenu.enabled = false;
	}
	
    // Prompt quit menu window and disable other buttons
	public void ExitPress()
    {
        quitMenu.enabled = true;
        startButton.enabled = false;
        exitButton.enabled = false;
    }

    // Return to main menu and re enable buttons
    public void No()
    {
        quitMenu.enabled = false;
        startButton.enabled = true;
        exitButton.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("scene1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Activation ...
    public void ShowInstructions()
    {
        instruction.enabled = true;
    }
    // ... and deactivation of the instructions screen
    public void closeInstructions()
    {
        instruction.enabled = false;
    }
}
