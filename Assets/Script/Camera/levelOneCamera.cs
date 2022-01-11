using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelOneCamera : MonoBehaviour
{
    public Transform player;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Update is called once per frame
    void Update()
    {  
        if(player.position != null){
            Vector3 playerPosition = player.position;
            playerPosition.x = Mathf.Clamp(playerPosition.x,minPosition.x,maxPosition.x);
            playerPosition.y = Mathf.Clamp(playerPosition.y,minPosition.y,maxPosition.y);
            transform.position = new Vector3(playerPosition.x,playerPosition.y,-10f);
        }
        
    }
}
