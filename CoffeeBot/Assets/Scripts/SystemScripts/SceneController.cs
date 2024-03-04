using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public void StartGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Tutorial");
        sceneInfo.Reset();
    }

    public void SkinSelection()
    {
        SceneManager.LoadScene("SkinSelectionScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Prototype 1");
        Time.timeScale = 1;

        
    }
}
