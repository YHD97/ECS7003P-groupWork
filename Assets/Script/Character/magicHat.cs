using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicHat : MonoBehaviour
{
    private bool canGetWeapon;
    private CharacterState characterState;
    private bool isGet;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        characterState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterState>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGet = characterState.getWeapon;
        if(isGet){
            Destroy(gameObject); 
        }
        // push E to save data in save point
        if(Input.GetKeyDown(KeyCode.E)){
            if(canGetWeapon && !isGet){
                Destroy(gameObject);
                isGet = true;
                characterState.getWeapon = true;
            }
            
        }
        
    }
    // Check if the player is at the save point
    void OnTriggerEnter2D(Collider2D other) {
        //the treasure box can open
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            canGetWeapon = true;
        } 
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            canGetWeapon = false;
            
            
        } 
    }
}
