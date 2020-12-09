using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class GameState

{
    public static int TimeToStart = 70;

    public static List<string> Levels = new List<string>()
    {
        "First", "Second", "Third", "Win"
    };

    public static int CurrentLevel = 0;

    internal static void LoadFirstLevel()
    {
        CurrentLevel = 0;
        LoadCurrentLevel();
    }

    public static void EndGame()
    {
#if DEBUG
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        return;
#endif
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