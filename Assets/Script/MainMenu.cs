/* 
1) Attach this script to the main menu object.
2) Drag main menu object in onClick of child object
3) Select function as necessary
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () 
    {
        // Load the first level
        SceneManager.LoadScene(1);
    }
}
