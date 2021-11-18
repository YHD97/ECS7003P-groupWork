using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject fireball;
    public int waitingTime;
    private float timer = 0;

    private GameObject instantiatedObj;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitingTime){
            //Action
            instantiatedObj = Instantiate(fireball, transform.position,transform.rotation);
            Destroy(instantiatedObj, waitingTime);
            timer = 0;
        }
    }
}
