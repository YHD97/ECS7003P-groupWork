using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public Text gameoverText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Fireball" || collision.gameObject.tag == "Acid Drop"){
            if(collision.gameObject.tag == "Fireball" || collision.gameObject.tag == "Acid Drop"){
                Destroy(collision.gameObject);
            }
            gameoverText.text = "GAME OVER!";
            this.gameObject.SetActive(false);
            Invoke("restartLevel", 2);
        }
    }

    private void restartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
