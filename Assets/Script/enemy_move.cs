using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftPoint;
    public Transform rightPoint;

    public float speed;

    private bool faceLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        //get the enemy position 
        rb = GetComponent <Rigidbody2D>();
        // Separating leftpoint and rightpoint from the enemy
        transform.DetachChildren();
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        // if enemy face left
        if (faceLeft)
        {
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            // if passed the left point position, return around
            if (transform.position.x < leftPoint.position.x)
            {
                transform.localScale = new Vector3(-1,1,1);
                faceLeft = false;
            }
        }else{
            rb.velocity = new Vector2(speed,rb.velocity.y);
            // if passed the right point position, return around
            if (transform.position.x > rightPoint.position.x)
            {
                transform.localScale = new Vector3(1,1,1);
                faceLeft = true;
            }
        }
    }
}
