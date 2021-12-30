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
        //playerData = GetComponent<NewPlayerMovement>().GetComponent<CharacterState>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(canSave){
                Save();
            }
            
        }
        
    }
    

    private void Save(){
        //save data
        PlayerPrefs.SetFloat("platerPositionX",player.position.x);
        PlayerPrefs.SetFloat("platerPositionY",player.position.y);
        PlayerPrefs.SetFloat("PlayerHealth",playerData.currentHealth);
        PlayerPrefs.Save();
        print("saved");
    }
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
