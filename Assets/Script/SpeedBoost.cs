/* Attach to game object.
This script improves jump and speed of the player
Adds Particles.
This only works for a certain duration.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public int rotationSpeed;
    public GameObject player;
    public GameObject particles;
    public int buffDuration;
    public float increaseSpeed;
    public float increaseJump;
    
    NewPlayerMovement playerMovement;
    private GameObject instantiatedParticles;
    private bool isNotGrabbed = true;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<NewPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime ));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isNotGrabbed)
        {
            if(collision.gameObject.tag == "Player"){
                // Instantiate particles
                instantiatedParticles = Instantiate(particles, player.transform.position, player.transform.rotation);
                instantiatedParticles.transform.parent = player.transform;
                playerMovement.speed += increaseSpeed;
                playerMovement.jumpSpeed += increaseJump;
                StartCoroutine(removeBuff());
                // Do not render but we want the script to still run
                gameObject.GetComponent<Renderer>().enabled = false;
                isNotGrabbed = false;
            }
        }
    }

    IEnumerator removeBuff()
    {
        while(buffDuration > 0)
        {
            yield return new WaitForSeconds(1);
            buffDuration--;
        }
        playerMovement.speed -= increaseSpeed;
        playerMovement.jumpSpeed -= increaseJump;
        Destroy(instantiatedParticles);
    }
}
