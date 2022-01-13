using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class treasureBox : MonoBehaviour
{
    public GameObject doorKeys;
    private bool canOpen;
    private bool isOpened;
    private Animator anim;
    private CharacterState characterState;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
        characterState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterState>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(characterState.getKey != 0){
            anim.SetTrigger("Opening");
            canOpen = false;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            if(canOpen && !isOpened){
                anim.SetTrigger("Opening");
                isOpened = true;
                Instantiate(doorKeys,transform.position,Quaternion.identity);
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        //the treasure box can open
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            canOpen = true;
        } 
    }

    //the treasure box cannot open
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            canOpen = false;
        } 
    }
}
