using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCamera : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    public float left_boundary = 0;
    public float bottom_boundary = 0;

    private float x, y = 0.0f;

    void Update()
    {
        // Camera cannot go anymore left
        if(player.position.x <= left_boundary) 
        {
            x = left_boundary;
        } else {
            x = player.position.x;
        }
        // Camera cannot go anymore below
        if(player.position.y <= bottom_boundary) 
        {
            y = bottom_boundary;
        } else {
            y = player.position.y;
        }

        transform.position = new Vector3(x, y,-10f);
    }
}
