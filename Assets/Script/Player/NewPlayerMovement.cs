using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;

    public Transform checkGround;
    public LayerMask Platforms;
    public float speed,jumpSpeed;
    
    public bool isGround,isJump;
    bool JumpPressed;
    int JumpCount;


    


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent <Rigidbody2D>();
       coll = GetComponent <Collider2D>();

    }
    void Update() {
        if(Input.GetButtonDown("Jump") && JumpCount > 0){
            JumpPressed = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Check if it is ground
        isGround = Physics2D.OverlapCircle(checkGround.position,0.1f,Platforms);

        groundMove();

        Jump();

    }

    void groundMove(){
        //move 
        float HorizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(HorizontalMove*speed,rb.velocity.y);
        // turn the face
        if (HorizontalMove != 0) {
            transform.localScale = new Vector3(HorizontalMove/2,transform.localScale.y,transform.localScale.z);
        }
    }

    void Jump(){
        // if is ground jump count is 2
        if(isGround){
            JumpCount = 2;
            isJump = false;
        }
        // check if it is pressed the key, if pressed, then jump
        if(JumpPressed && isGround){
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
            JumpCount--;
            JumpPressed = false;
        }
        // second time jump
        else if(JumpPressed && JumpCount > 0 && !isGround){
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
            JumpCount--;
            JumpPressed = false;
        }

    }
}
