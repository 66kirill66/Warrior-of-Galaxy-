using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
    
    public void NewGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
