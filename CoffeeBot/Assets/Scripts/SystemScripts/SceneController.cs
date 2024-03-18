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

    public void SetSkin1()
    {
        sceneInfo.SkinCounter = 1;
    }

    public void SetSkin2()
    {
        sceneInfo.SkinCounter = 2;
    }

    public void SetSkin3()
    {
        sceneInfo.SkinCounter = 3;
    }

    public void SetSkin4()
    {
        sceneInfo.SkinCounter = 4;
    }
    public void SetSkin5()
    {
        sceneInfo.SkinCounter = 5;
    }
}
