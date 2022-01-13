using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public CharacterData_SO templateData;
    public CharacterData_SO CharacterData;

    //Use a temporary variable to store data
    //prevent the death of one enemy followed by the death of the others
    void Awake() {
        if(templateData != null){
            CharacterData = Instantiate(templateData);
        }
    }
    // read the data from data_So
    public int maxHealth { 
        get{if(CharacterData != null){return CharacterData.maxHealth;}else{return 0;}} 
        set{CharacterData.maxHealth = value;} 
    }
    public int currentHealth { 
        get{if(CharacterData != null){return CharacterData.currentHealth;}else{return 0;}} 
        set{CharacterData.currentHealth = value;} 
    }
    public int baseDefence { 
        get{if(CharacterData != null){return CharacterData.baseDefence;}else{return 0;}} 
        set{CharacterData.baseDefence = value;} 
    }
    public int currentDefence { 
        get{if(CharacterData != null){return CharacterData.currentDefence;}else{return 0;}} 
        set{CharacterData.currentDefence = value;} 
    }

    public float playerPositionX { 
        get{if(CharacterData != null){return CharacterData.playerPositionX;}else{return 0.0f;}} 
        set{CharacterData.playerPositionX = value;} 
    }

    public float playerPositionY { 
        get{if(CharacterData != null){return CharacterData.playerPositionY;}else{return 0.0f;}} 
        set{CharacterData.playerPositionY = value;} 
    }
    public int getKey { 
        get{if(CharacterData != null){return CharacterData.getKey;}else{return 0;}} 
        set{CharacterData.getKey = value;} 
    }

    public bool getWeapon { 
        get{if(CharacterData != null){return CharacterData.getWeapon;}else{return true;}} 
        set{CharacterData.getWeapon = value;} 
    }

    // take damage
    public void takeDamage(CharacterState Attacker,CharacterState defener){
        int damage = Mathf.Max(Attacker.CurrentDamage()-defener.currentDefence,0);
        currentHealth = Mathf.Max(currentHealth - damage,0);
    }
    
    // calculate damage
    private int CurrentDamage()
    {
        float coreDamage = UnityEngine.Random.Range(CharacterData.minDamage,CharacterData.maxDamage);
        return (int)coreDamage;
    }
}
