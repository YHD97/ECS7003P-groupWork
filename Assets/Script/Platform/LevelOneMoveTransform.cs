using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneMoveTransform : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;

    public float speed;

    private Rigidbody2D rb;
    //bool for face is left
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
                transform.localScale = new Vector3(-rb.transform.localScale.x, rb.transform.localScale.y,rb.transform.localScale.z);
                faceLeft = false;
            }
        }else{
            rb.velocity = new Vector2(speed,rb.velocity.y);
            // if passed the right point position, return around
            if (transform.position.x > rightPoint.position.x)
            {
                transform.localScale = new Vector3(-rb.transform.localScale.x,rb.transform.localScale.y,rb.transform.localScale.z);
                faceLeft = true;
            }
        }
    }
}
