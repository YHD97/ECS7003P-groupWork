/* 
Attach this script to the door to reach the next level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public Text completeText;
    public AudioSource sfxNextLevel;
    // Start is called before the first frame update
    void Start()
    {
        completeText.text = "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(sfxNextLevel != null){
                sfxNextLevel.Play();
            }
            completeText.text = "YOU HAVE COMPLETED THE LEVEL!";
            Invoke("nextLevel", 3);
        }
    }

    void nextLevel() 
    {
        if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        } 
        else if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(2);
            GlobalPrefs.SaveCurrentLevel(2);
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GlobalPrefs.SaveCurrentLevel(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
