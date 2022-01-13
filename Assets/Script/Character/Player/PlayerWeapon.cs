using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject fireball;
    public AudioSource sfxFireball;
    public int destroyFireballTime;
    private GameObject fireball2;
    private CharacterState characterState;

    // Start is called before the first frame update
    void Start()
    {
        characterState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterState>();

    }

    // Update is called once per frame
    void Update()
    {   
        if(characterState.getWeapon){
            if(Input.GetKeyDown(KeyCode.J)){
                if(sfxFireball != null)
                {
                sfxFireball.PlayOneShot(sfxFireball.clip);
                }
            fire();
        }
            
        }
        
       
        
    }
    
    void fire(){
        fireball2 = Instantiate(fireball,transform.position,transform.rotation);
        Destroy(fireball2,destroyFireballTime);
    }
}
