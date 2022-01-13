/* 
1) Attach this script to the menu canvas.
2) Drag menu object in onClick of child object
3) Select function as necessary
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject rules;
    public GameObject options;

    public void playGame() 
    {
        //Delate All save data
        PlayerPrefs.DeleteAll();

        // Save current level
        GlobalPrefs.SaveCurrentLevel(1);

        // Load the first level
        SceneManager.LoadScene(1);
    }

    public void playGameHarder() 
    {
        //Delate All save data
        PlayerPrefs.DeleteAll();

        // Save current level
        GlobalPrefs.SaveCurrentLevel(4);

        // Load the first level
        SceneManager.LoadScene(4);
    }

    public void playTutorial() 
    {
        // Load the first level
        SceneManager.LoadScene(3);
    }

    public void loadGame() 
    {
        // Load game from checkpoint
        int level = GlobalPrefs.LoadCurrentLevel();
        if (level != 0) {
            SceneManager.LoadScene(level);
        }
    }

    public void backToMainMenu(GameObject currentObject)
    {
        // Set current object as false and main menu as true
        mainMenu.SetActive(true);
        currentObject.SetActive(false);
    }

    public void showRules()
    {
        // Show rules and do not show main menu
        rules.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void showOptions()
    {
        // Show options and do not show main menu
        options.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void resume(){
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void quitGame() 
    {
        // Load main menu
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void restartLevel() 
    {
        // Load current scene
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}
