using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;
    public Text gameoverText;

    private GameObject[] targets;
    private int currentTargetIndex;
    private int targetLength;

    private Camera camera;
    private bool isMoving;

    void Start()
    {
        camera = GetComponent<Camera>();
        isMoving = true;
        gameoverText.text = "";
        targets = GameObject.FindGameObjectsWithTag("Camera Target").OrderBy(go => go.transform.position.x).ToArray();
        targetLength = targets.Length;
        currentTargetIndex = 0;
        transform.DetachChildren();
    }

    void Update()
    {
        CheckPlayerTouchedLeft();
        //Moves the GameObject from it's current position to destination over time
        if (isMoving) {
            if(transform.position.x < targets[currentTargetIndex].transform.position.x) {
                transform.position = Vector3.MoveTowards(transform.position, targets[currentTargetIndex].transform.position, Time.deltaTime * speed);
            } else {
                if(currentTargetIndex < targetLength - 1) {
                    currentTargetIndex = currentTargetIndex + 1;
                }
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
