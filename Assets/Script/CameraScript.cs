using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;
    public Transform target1;
    public Transform target2;
    public Text gameoverText;


    private Camera camera;
    private bool IsMoving;

    void Start()
    {
        camera = GetComponent<Camera>();
        IsMoving = true;
        gameoverText.text = "";
        transform.DetachChildren();
    }

    void Update()
    {
        CheckPlayerTouchedLeft();
        //Moves the GameObject from it's current position to destination over time
        if (IsMoving) {
            if(transform.position.x < target1.position.x) {
                transform.position = Vector3.MoveTowards(transform.position, target1.position, Time.deltaTime * speed);
            } else {
                transform.position = Vector3.MoveTowards(transform.position, target2.position, Time.deltaTime * speed);
            }
        }
    }

    void CheckPlayerTouchedLeft()
    {
        Vector3 screenPos = camera.WorldToViewportPoint(player.transform.position);
        if (screenPos.x < 0.0 || screenPos.y < 0.0) {
            gameoverText.text = "GAME OVER!";
            Invoke("restartLevel", 2);
        }
    }

    void restartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
