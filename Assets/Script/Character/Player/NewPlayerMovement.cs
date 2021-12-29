using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private CharacterState characterState;

    public Transform checkGround;
    public LayerMask Platforms;
    public float speed,jumpSpeed;
    
    public bool isGround,isJump;
    bool JumpPressed;
    int JumpCount;

    public Vector2 moveValue;




    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent <Rigidbody2D>();
       coll = GetComponent <Collider2D>();
       characterState = GetComponent<CharacterState>();
    }

    void Update() {
        if((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)) && JumpCount > 0){
            JumpPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Load();

        }
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Check if it is ground
        isGround = Physics2D.OverlapCircle(checkGround.position,0.1f,Platforms);

        groundMove();

        Jump();

    }
    #region Player movement
    //get the input value
    void OnMove(InputValue value) 
    { 
        moveValue = value.Get<Vector2>();
    }

    void groundMove(){
        rb.velocity = new Vector2(moveValue.x*speed,rb.velocity.y);
        // turn the face
        if (moveValue.x != 0) {
            transform.localScale = new Vector3(moveValue.x/2,transform.localScale.y,transform.localScale.z);
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

    #endregion

    //TODO: player attack


    




    private void Load(){
        
        if(PlayerPrefs.HasKey("platerPositionX")){
            //Load data
            float platerPositionX = PlayerPrefs.GetFloat("platerPositionX");
            float platerPositionY = PlayerPrefs.GetFloat("platerPositionY");
            transform.position = new Vector3(platerPositionX,platerPositionY,transform.position.z);
        }else{
            print("No data");
        }
        
    }
}
