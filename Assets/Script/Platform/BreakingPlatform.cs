using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    private Animator anim;
    public AudioSource sfxCrumblingRocks;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(sfxCrumblingRocks != null) {
                sfxCrumblingRocks.PlayOneShot(sfxCrumblingRocks.clip);
            }
            anim.Play("Breaking Platform Animation");
            Destroy(gameObject, 0.5f);
        }
    }
}
