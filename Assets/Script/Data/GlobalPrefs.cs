using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalPrefs
{
    public static void SaveCurrentLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
    }

    public static int LoadCurrentLevel()
    {
        int currentLevel = 0;

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        return currentLevel;
    }
}