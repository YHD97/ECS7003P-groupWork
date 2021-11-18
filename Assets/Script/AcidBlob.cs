using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AcidBlob : MonoBehaviour
{
    public Transform topPoint;
    public Transform bottomPoint;
    public Text gameoverText;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.y < bottomPoint.position.y)
        {
            transform.position = new Vector3(topPoint.position.x, topPoint.position.y, topPoint.position.z);
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Destroy(collision.gameObject);
            gameoverText.text = "GAME OVER!";
            this.gameObject.SetActive(false);
            Invoke("restartLevel", 2);
        } else {
            transform.position = new Vector3(topPoint.position.x, topPoint.position.y, topPoint.position.z);
            rb.velocity = Vector2.zero;
        }
    }

    private void restartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
