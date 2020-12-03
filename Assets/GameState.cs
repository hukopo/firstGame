using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameState

    {
    public static List<float> playerMovementsX = new List<float>();
    public static List<bool> playerJumps = new List<bool>();
        
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
