using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    public CharacterState playerStates;
    
    private void RegisterPlayer(CharacterState player){
        playerStates = player;

    }
}
