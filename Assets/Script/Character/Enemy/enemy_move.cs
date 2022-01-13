using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class enemy_move : MonoBehaviour
{
   
    public Transform leftPoint;
    public Transform rightPoint;
    public AudioSource sfxDeath;
   

    public float speed;
    public float startWaitTime;
    private float waitTime;
    public float playerToEnemy;
    

    private Rigidbody2D rb;
    private Transform playerTransform;
    private CharacterState characterState;
    
    // Start is called before the first frame update
    public Text gameoverText;
    public Transform movePosition;
    
    public void Start()
    {
        //get the enemy position 
        rb = GetComponent <Rigidbody2D>();
        characterState = GetComponent<CharacterState>();
        // Separating leftpoint and rightpoint from the enemy
        transform.DetachChildren();
        characterState.currentHealth = 100;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        waitTime = startWaitTime;
        movePosition.position = getRandomPosition();        
    }

    // Update is called once per frame
    public void Update()
    {
        //the enemy pursuit function
        if(playerTransform != null){
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if(distance < playerToEnemy*playerToEnemy){
                movePosition.position = new Vector2(playerTransform.position.x,playerTransform.position.y);
            }
        }
        // Check the face direction
        if (rb.transform.position.x < movePosition.transform.position.x){
            transform.localScale = new Vector3(-Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y,rb.transform.localScale.z);
        }else{
            transform.localScale = new Vector3(Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y,rb.transform.localScale.z);

        }

        EnemyMovement();
        
        //enemy died soud
        if(characterState.currentHealth <= 0){
            if(sfxDeath != null)
            {
                sfxDeath.PlayOneShot(sfxDeath.clip);
            }
            Destroy(gameObject);
        }
    }


    #region enemy movement
    void EnemyMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePosition.position,7.0f*Time.deltaTime);
        if(Vector2.Distance(transform.position,movePosition.position) < 0.1f){
            if(waitTime<=0){
                movePosition.position = getRandomPosition();
                waitTime = startWaitTime;
            }else{
                waitTime -= Time.deltaTime; 
            }
        } 
    }
    // get a random point for enemy next move
    Vector2 getRandomPosition(){
        Vector2 rndPosition = new Vector2(Random.Range(leftPoint.position.x,rightPoint.position.x),transform.position.y);
        return rndPosition;
    }
    
    #endregion

    // enemy attack
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            // find the enemy states
            var targetStates = other.GetComponent<NewPlayerMovement>().GetComponent<CharacterState>();
            // make the damage
            targetStates.takeDamage(characterState,targetStates);
        }
    }


}
