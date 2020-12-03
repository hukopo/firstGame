using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameState

    {
        public static bool isOver = false;
        
        public static void EndGame()
        {
            Debug.Log("Fuck u");
            SceneManager.LoadScene("Death1");
        }

    public static void Restart() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
