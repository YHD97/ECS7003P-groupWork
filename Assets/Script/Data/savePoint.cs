using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{
    public Transform player;
    private bool canSave;
    public CharacterState playerData;
     
   
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // push E to save data in save point
        if(Input.GetKeyDown(KeyCode.E)){
            if(canSave){
                SaveManager.Instance.SavePlayerData();
            }
            
        }
        
    }
    
    // Check if the player is at the save point
    void OnTriggerEnter2D(Collider2D other) {
        //the treasure box can open
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            canSave = true;
        } 
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            canSave = false;
        } 
    }
    

}
