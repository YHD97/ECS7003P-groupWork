using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatformVerticle : MonoBehaviour
{
    public float speed;
    public Transform topPoint;
    public Transform bottomPoint;

    private Rigidbody2D rb;
    private bool moveUp = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        // Separating topPoint and bottomPoint from the enemy
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform() 
    {
        if (moveUp) 
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y >= topPoint.position.y)
            {
                moveUp = false;
            }
        } else {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y <= bottomPoint.position.y)
            {
                moveUp = true;
            }
        }
    }

}
