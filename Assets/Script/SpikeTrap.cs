using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    public float rotationSpeed;

    public Text gameoverText;

    // Update is called once per frame
    void Start() 
    {
        gameoverText.text = "";
    }

    void Update()
    {
        transform.Rotate(new Vector3( 0, 0, rotationSpeed * Time.deltaTime ));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Destroy(collision.gameObject);
            gameoverText.text = "GAME OVER!";
            Invoke("restartLevel", 2);
        }
        
    }

    private void restartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
