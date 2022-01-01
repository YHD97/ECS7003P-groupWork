using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New data", menuName = "Data/CharacterData")]
public class CharacterData_SO : ScriptableObject {
    
    public int maxHealth;
    public int currentHealth;
    public int baseDefence;
    public int currentDefence;
    public float minDamage;
    public float maxDamage;
    public float playerPositionX;
    public float playerPositionY;



}

