/* Attach this script the player */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public Text gameoverText;
    public GameObject deathParticles;
    public AudioSource sfxDeath;

    private GameObject instantiatedParticles;
    private CharacterState characterState;

    void Start() {
        characterState = GetComponent<CharacterState>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Fireball" || collision.gameObject.tag == "Acid Drop"){
            if(collision.gameObject.tag == "Fireball" || collision.gameObject.tag == "Acid Drop"){
                Destroy(collision.gameObject);
            }
            // Instantiate splatter particles on death.
            instantiatedParticles = Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);
            // Play death audio effect
            if(sfxDeath != null){
                sfxDeath.Play();
            }
            // Destroy particles
            Destroy(instantiatedParticles, 5.0f);
            // Show game over
            gameoverText.text = "GAME OVER!";
            this.gameObject.SetActive(false);
            // Restart the level
            Invoke("restartLevel", 2);
        } 
        if(characterState.currentHealth <= 0.0f){
            instantiatedParticles = Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);
            // Play death audio effect
            if(sfxDeath != null){
                sfxDeath.Play();
            }
            // Destroy particles
            Destroy(instantiatedParticles, 5.0f);
            // Show game over
            gameoverText.text = "GAME OVER!";
            this.gameObject.SetActive(false);
            // Restart the level
            Invoke("restartLevel", 2);
        }
    }

    private void restartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
       
    }
}
