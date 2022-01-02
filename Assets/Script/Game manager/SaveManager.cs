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
    
    // save data
    public void SavePlayerData(){
        Save(GameManager.Instance.playerStates.CharacterData,GameManager.Instance.playerStates.CharacterData.name);
        print("data save");
        

    }

    //Load data
    public void LoadPlayerData(){
        Load(GameManager.Instance.playerStates.CharacterData,GameManager.Instance.playerStates.CharacterData.name);
        print("data Load");

    }

    // Convert data to json data and save
    public void Save(Object data, string key){
        var jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key,jsonData);
        PlayerPrefs.Save();

    }

    // Load data from json data
    public void Load(Object data, string key){
        if(PlayerPrefs.HasKey(key)){
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key),data);
        }else{
            print("No data");
        }
    }
}
