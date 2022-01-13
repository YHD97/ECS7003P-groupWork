using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public  int healthCurrent;
    public  int maxHealth;
    private Image healthBar;
    private CharacterState characterState;
    // Start is called before the first frame update
    void Start()
    {
        characterState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterState>();
        healthBar = GetComponent<Image>();
        maxHealth = characterState.maxHealth;
        healthCurrent = characterState.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = characterState.maxHealth;
        healthCurrent = characterState.currentHealth;
        healthBar.fillAmount = (float)healthCurrent/(float)maxHealth;
        healthText.text = healthCurrent.ToString()+"/" +maxHealth.ToString();
    }
}
