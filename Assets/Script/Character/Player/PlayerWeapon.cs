using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject fireball;
    public AudioSource sfxFireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            if(sfxFireball != null)
            {
                sfxFireball.PlayOneShot(sfxFireball.clip);
            }
            fire();
        }
    }
    
    void fire(){
        Instantiate(fireball,transform.position,transform.rotation);
    }
}
