using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject fireball;
    public int respawnTime;
    public int killObjectTime;
    private float timer = 0;

    private GameObject instantiatedObj;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > respawnTime){
            //Action
            instantiatedObj = Instantiate(fireball, transform.position,transform.rotation);
            Destroy(instantiatedObj, killObjectTime);
            timer = 0;
        }
    }
}
