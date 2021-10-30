using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movespeed = 3;
    public float jumpspeed = 10;
    public float timeVal;
    private bool faceLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Ridgidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(timeVal>=0.4f)
        {
            Move();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * movespeed * Time.deltaTime, Space.World);

        float v = Input.GetAxisRaw("Jump");
        transform.Translate(Vector3.up * v * jumpspeed * Time.deltaTime, Space.World);

        if(faceLeft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            if(Vector3.right<0)
            {
                faceLeft = false;
            }
            else
            {
                faceLeft = true;
            }
        }
    }
}
