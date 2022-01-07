using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public int StartKeyQuantity;
    public Text KeyQuantity;
    public static int CurrentKeyQuantity;
    // Start is called before the first frame update
    void Start()
    {
        // start key number is 0
        CurrentKeyQuantity = StartKeyQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        // update the key UI
        KeyQuantity.text = CurrentKeyQuantity.ToString();
    }
}
