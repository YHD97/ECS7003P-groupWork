using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public CharacterData_SO CharacterData;
    // read the data from data_So
    public int maxHealth { 
        get{if(CharacterData != null){return CharacterData.maxHealth;}else{return 0;}} 
        set{CharacterData.maxHealth = value;} 
    }
    public int currentHealth { 
        get{if(CharacterData != null){return CharacterData.currentHealth;}else{return 0;}} 
        set{CharacterData.currentHealth = value;} 
    }
    public int baseDefnce { 
        get{if(CharacterData != null){return CharacterData.baseDefnce;}else{return 0;}} 
        set{CharacterData.baseDefnce = value;} 
    }
    public int currentDefnce { 
        get{if(CharacterData != null){return CharacterData.currentDefnce;}else{return 0;}} 
        set{CharacterData.currentDefnce = value;} 
    }
}
