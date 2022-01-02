using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public static float MainVolume { get; set; } = 1.0f;
    public static float MusicVolume { get; set; } = 1.0f;
    public static float EffectsVolume { get; set; } = 1.0f;

    public static float Gamma { get; set; } = 1.0f;
    public static bool ShowCountdownOnLevelStart { get; set; } = true;
    public static bool startGame { get; set; } = true;
}
