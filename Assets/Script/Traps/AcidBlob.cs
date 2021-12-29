using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBlob : MonoBehaviour
{
    public Transform topPoint;
    public Transform bottomPoint;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.y < bottomPoint.position.y)
        {
            transform.position = new Vector3(topPoint.position.x, topPoint.position.y, topPoint.position.z);
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = new Vector3(topPoint.position.x, topPoint.position.y, topPoint.position.z);
        rb.velocity = Vector2.zero;
    }

}
