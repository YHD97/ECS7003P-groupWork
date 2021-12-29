using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour
{
    public float speed;
    public float minDamage;
    public float maxDamage;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private Transform fireBallTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fireBallTransform = GetComponent<Transform>();
        if(playerTransform.localScale.x >0){
            rb.velocity = transform.right *speed;
        }
        else{
            rb.velocity = -transform.right *speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,0);
        //transform.position = new Vector3(-playerTransform.position.x*speed,playerTransform.position.y,playerTransform.position.z);

    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            other.GetComponent<enemy_move>().takeDamage(minDamage);
            Destroy(gameObject);
        }
    }
}
