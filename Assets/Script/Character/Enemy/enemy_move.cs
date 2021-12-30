using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemy_move : MonoBehaviour
{
   
    public Transform leftPoint;
    public Transform rightPoint;
   

    public float speed;
    

    private Rigidbody2D rb;
    private CharacterState characterState;
    //bool for face is left
    private bool faceLeft = true;
    // Start is called before the first frame update
    public Text gameoverText;
    private Transform playerTransform;
    void Start()
    {
        //get the enemy position 
        rb = GetComponent <Rigidbody2D>();
        characterState = GetComponent<CharacterState>();
        // Separating leftpoint and rightpoint from the enemy
        transform.DetachChildren();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        characterState.currentHealth = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        if(playerTransform != null){
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if(distance < 5.0){
                transform.position = Vector2.MoveTowards(transform.position,playerTransform.position,speed*Time.deltaTime);
                
            }
        }
        if(characterState.currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    

    


    #region enemy movement
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
    #endregion


}
