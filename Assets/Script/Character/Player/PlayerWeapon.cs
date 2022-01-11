using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject fireball;
    public AudioSource sfxFireball;
    public int destroyFireballTime;
    private GameObject fireball2;
    
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
        fireball2 = Instantiate(fireball,transform.position,transform.rotation);
        Destroy(fireball2,destroyFireballTime);
    }
}
