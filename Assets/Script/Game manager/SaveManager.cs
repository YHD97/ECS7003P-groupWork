using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.B)){
            //Save(GameManager.Instantiate.playerStates.chara)

        }
        if(Input.GetKeyDown(KeyCode.N)){
            
        }
    }
    public void Save(Object data, string key){
        var jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key,jsonData);
        PlayerPrefs.Save();

    }
    public void Load(Object data, string key){
        if(PlayerPrefs.HasKey(key)){
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key),data);
        }
    }
}
