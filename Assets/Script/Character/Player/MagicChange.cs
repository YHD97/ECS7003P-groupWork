using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicChange : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MagicHat")
        {
            anim.Play("MagicMode");
        }
    }
}
