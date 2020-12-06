using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class GameState

    {
    public static List<float> playerMovementsX = new List<float>();
    public static List<bool> playerJumps = new List<bool>();
    public static List<string> Levels = new List<string>()
    {
        "SampleScene", "level9", "Win"
    };
    public static int CurrentLevel = 0;

    internal static void LoadFirstLevel()
    {
        CurrentLevel = 0;
        LoadCurrentLevel();
    }

    public static void EndGame()
        {
            SceneManager.LoadScene("Death1");
        }

    public static void Restart() 
    {
        LoadCurrentLevel();
    }

    internal static void LoadNextLevel()
    {
        CurrentLevel++;
        LoadCurrentLevel();
    }
    private static void LoadCurrentLevel()
    {
        SceneManager.LoadScene(Levels[CurrentLevel]);
    }
}
