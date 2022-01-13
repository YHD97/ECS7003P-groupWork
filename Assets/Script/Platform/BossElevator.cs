using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossElevator : MonoBehaviour
{
    public float speed;
    public Transform topPoint;
    public Transform bottomPoint;
    //public GameObject Boss;

    private Rigidbody2D rb;
    private bool moveUp = true;
    private bool isMoving = false;
    private CharacterState characterState;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Separating topPoint and bottomPoint from the enemy
        transform.DetachChildren();
        //characterState = GameObject.FindGameObjectWithTag("Boss").GetComponent<CharacterState>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        //if (isMoving)
        //{
            if (moveUp)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                if (transform.position.y >= topPoint.position.y)
                {
                    moveUp = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                if (transform.position.y <= bottomPoint.position.y)
                {
                    moveUp = true;
                }
            }
        //}

    }

    //void Move()
    //{
        //if (characterState.currentHealth <= 0.0f)
        //{
            //isMoving = true;
        //}
    //}
}