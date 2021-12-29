using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange;
    public float minDamage;
    public float maxDamage;
    public int maxHealth;
    public int currentHealth;
    public int baseDefence;
    public int currentDefence;

    public GameObject fireball;
    public int respawnTime;
    public int killObjectTime;
    private float timer = 0;
    private GameObject instantiatedObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    void attack(){
        if(Input.GetKeyDown(KeyCode.J)){
            timer += Time.deltaTime;
            if(timer > respawnTime){
                //Action
                instantiatedObj = Instantiate(fireball, transform.position,transform.rotation);
                Destroy(instantiatedObj, killObjectTime);
                timer = 0;
            }
            
        }

    }

    
}
