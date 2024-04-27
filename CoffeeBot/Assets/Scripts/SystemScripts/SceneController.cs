using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SceneController : MonoBehaviour
{
    public SceneInfo sceneInfo;


    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;

    [SerializeField] private Button continueGameButton;

    public static bool NewGamePressed = false;

    public void OnNewGameClicked()
    {
        NewGamePressed = true;
        SceneManager.LoadSceneAsync("SkinSelectionScreen");
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        
    }

    public void OnContinueGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
        //DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync("Prototype 1");
        NewGamePressed = false;
    }

    public void OnSaveGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();
    }

    public void OnLoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();

    }

    public void Awake()
    {
        Cursor.visible = true;
    }

    private void Start()
    {       
        if(!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }
    public void StartTutorial()
    {
        Cursor.visible = true;
        SceneManager.LoadSceneAsync("Tutorial");
        sceneInfo.Reset();
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Prototype 1");
        
        //Time.timeScale = 1;
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
