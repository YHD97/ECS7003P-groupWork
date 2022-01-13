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
    private CharacterState characterState;
    // Start is called before the first frame update
    void Start()
    {
        completeText.text = "";
        characterState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(characterState.getKey!=0){
                if(sfxNextLevel != null){
                sfxNextLevel.Play();
            }
            completeText.text = "YOU HAVE COMPLETED THE LEVEL!";
            Invoke("nextLevel", 3);

            }else{
                completeText.text = "Please Get the Key";
            }
        }
    }

    void nextLevel() 
    {
        if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        } 
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GlobalPrefs.SaveCurrentLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
