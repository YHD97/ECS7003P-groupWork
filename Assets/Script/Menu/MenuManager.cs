/*
Script to show menu on hitting esc. 
1) Add to Game Controller Object.
2) Drag gameMenu object to script variable.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject gameMenu;

    // Update is called once per frame
    void Update()
    {
        // If escape is pressed, make the game object active
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            gameMenu.SetActive(true);
        }
    }
}
