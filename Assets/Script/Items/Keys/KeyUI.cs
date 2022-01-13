using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public int StartKeyQuantity;
    public Text KeyQuantity;
    public static int CurrentKeyQuantity;
    private CharacterState characterState;
    // Start is called before the first frame update
    void Start()
    {
        characterState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterState>();

        // start key number is 0
        CurrentKeyQuantity = characterState.getKey;
        
    }

    // Update is called once per frame
    void Update()
    {
        characterState.getKey = CurrentKeyQuantity; 
        // update the key UI
        KeyQuantity.text = CurrentKeyQuantity.ToString();
    }
}
