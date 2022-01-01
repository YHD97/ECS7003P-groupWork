using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private Transform fireBallTransform;
    private CharacterState characterState;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterState>();
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fireBallTransform = GetComponent<Transform>();
        if(playerTransform.localScale.x >0){
            rb.velocity = transform.right *speed;
        }
        else{
            rb.velocity = -transform.right *speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,0);

    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            // find the enemy states
            var targetStates = other.GetComponent<enemy_move>().GetComponent<CharacterState>();
            // make the damage
            targetStates.takeDamage(characterState,targetStates);
            Destroy(gameObject);
        }
    }
}
