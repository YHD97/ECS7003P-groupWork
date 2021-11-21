using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyPlatform : MonoBehaviour
{
    public GameObject player;
    public Transform rightPoint;
    public Transform leftPoint;

    private bool playerCollided;

    // Update is called once per frame
    void Update()
    {
        if(playerCollided){
            if(player.transform.localScale.x < 0) {
                player.transform.position = Vector2.Lerp(player.transform.position, leftPoint.position, Time.deltaTime);
            } else {
                player.transform.position = Vector2.Lerp(player.transform.position, rightPoint.position, Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            playerCollided = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            playerCollided = false;
        }
    }
}
