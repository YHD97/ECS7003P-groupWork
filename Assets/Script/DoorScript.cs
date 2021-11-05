using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public Text completeText;
    // Start is called before the first frame update
    void Start()
    {
        completeText.text = "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Destroy(collision.gameObject);
            completeText.text = "YOU HAVE COMPLETED THE LEVEL!";
            Invoke("nextLevel", 5);
        }
    }

    void nextLevel() 
    {
        // ToDo when we have more levels, for now restart level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
