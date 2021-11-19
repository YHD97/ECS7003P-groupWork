using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float speed;
    public Transform end;
    public GameObject playerPlaceholder;

    private Rigidbody2D rb;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (transform.position.x > end.position.x){
            isMoving = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(playerPlaceholder.transform, true);
            isMoving = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
