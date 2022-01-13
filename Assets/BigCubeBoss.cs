using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BigCubeBoss : MonoBehaviour
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

    //second stage
    public GameObject fireball;
    public int respawnTime;
    public int killObjectTime;
    private float timer = 0;
    private GameObject instantiatedObj;
    
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
        characterState.currentHealth = 500;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        waitTime = startWaitTime;
        movePosition.position = transform.position;        
    }

    // Update is called once per frame
    public void Update()
    {   
        enemyPursuit();
        
        checkFaceDirection();

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
                movePosition.position = transform.position;
                waitTime = startWaitTime;
            }else{
                waitTime -= Time.deltaTime; 
            }
        } 
    }

    void enemyPursuit(){
            //the enemy pursuit function
            if(playerTransform != null){
                float distance = (transform.position - playerTransform.position).sqrMagnitude;
                if(distance < playerToEnemy*playerToEnemy){
                    movePosition.position = new Vector2(playerTransform.position.x,playerTransform.position.y);
                }
            }
        }

    void checkFaceDirection(){
        // Check the face direction
        if (rb.transform.position.x < movePosition.transform.position.x){
            transform.localScale = new Vector3(-Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y,rb.transform.localScale.z);
        }else{
            transform.localScale = new Vector3(Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y,rb.transform.localScale.z);

        }
    }

   void secondStageAttack(){
       timer += Time.deltaTime;
        if(timer > respawnTime){
            //Action
            movePosition.position = new Vector2(rightPoint.position.x-1.0f,rightPoint.position.y);
            instantiatedObj = Instantiate(fireball, transform.position,transform.rotation);
            Destroy(instantiatedObj, killObjectTime);
            timer = 0;
            
        }
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
