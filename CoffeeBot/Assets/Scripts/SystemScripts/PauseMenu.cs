using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour, IDataPersistence
{
    [SerializeField] private PlayerInputActions playerInputActions;
    [SerializeField] private InputAction menu;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private GameObject endOfDayUI;
    [SerializeField] private GameObject unlockCoffeeUI;
    [SerializeField] private GameObject optionsUI;




    [SerializeField] private bool isPaused;

    [SerializeField]
    public SceneInfo sceneInfo;
    public DayTimer dayTimer;

    public bool isNextScene = true;
    public bool isPrisoner = false;

    public TotalInjuryCounter totalInjuryCounter;
    private void Awake()
    {
       playerInputActions = new PlayerInputActions();
       
    }

    private void Update()
    {
        if(totalInjuryCounter.totalInjuryCounter >= 10)
        {
            isPrisoner = true;
        }
    }

    private void OnEnable()
    {
        menu = playerInputActions.Menu.Escape;
        menu.Enable();
       
        menu.performed += Pause;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if(isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
            DeactivateUpgradesMenu();
            DeactivateUnlockCoffeeMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        //Audiolistener.pause = true;
        pauseUI.SetActive(true);
        Cursor.visible = true;
        playerInputActions.Player.Disable();
        playerInputActions.Player.Flip.Disable();
    }
    public void ActivateUpgradesMenu()
    {
        Time.timeScale = 0;
        //Audiolistener.pause = true;
        upgradeUI.SetActive(true);
        Cursor.visible = true;
        playerInputActions.Player.Disable();
        playerInputActions.Player.Flip.Disable();
    }

    public void ActivateEndOfDayMenu()
    {
        Time.timeScale = 0;
        //Audiolistener.pause = true;
        endOfDayUI.SetActive(true);
        Cursor.visible = true;
        playerInputActions.Player.Disable();
        playerInputActions.Menu.Disable();
        playerInputActions.Player.Flip.Disable();
    }
    public void DeactivateEndOfDayMenu()
    {
        Time.timeScale = 1;
        //Audiolistener.pause = false;
        endOfDayUI.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        playerInputActions.Player.Enable();
        playerInputActions.Player.Flip.Enable();
    }

    public void DeactivateUnlockCoffeeMenu()
    {
        Time.timeScale = 1;
        //Audiolistener.pause = false;
        unlockCoffeeUI.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        playerInputActions.Player.Enable();
        playerInputActions.Player.Flip.Enable();
    }




    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        //Audiolistener.pause = false;
        pauseUI.SetActive(false);
        optionsUI.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        playerInputActions.Player.Enable();
        playerInputActions.Player.Flip.Enable();


    }
    public void DeactivateUpgradesMenu()
    {
        Time.timeScale = 1;
        //Audiolistener.pause = false;
        upgradeUI.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        playerInputActions.Player.Enable();
        playerInputActions.Player.Flip.Enable();


    }


    public void ResetScene()
    {
        SceneManager.LoadScene("Prototype 1");
        Time.timeScale = 1;
        DeactivateMenu();

        sceneInfo.isNextScene = isNextScene;
        sceneInfo.Reset();      
    }

    public void ResetTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1;
        DeactivateMenu();
        
        sceneInfo.Reset();
    }

    public void NextDay()
    {
        sceneInfo.dayCount++;
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene("Prototype 1");
        Time.timeScale = 1;
        DeactivateMenu();
        DeactivateUpgradesMenu();
        dayTimer.currentTime = 180f;

        
        
        
        
        
  
        if (sceneInfo.dayCount >= 5 && sceneInfo.money <= 200 && isPrisoner == false)
        {
            SceneManager.LoadScene("BadEnding");
            DeactivateMenu();
            DeactivateUpgradesMenu();
            Cursor.visible = true;
            sceneInfo.Reset();
        }
        if (sceneInfo.dayCount >= 5 && sceneInfo.money > 200 && isPrisoner == false)
        {
            SceneManager.LoadScene("GoodEnding");
            DeactivateUpgradesMenu();
            Cursor.visible = true;
            sceneInfo.Reset();
        }
       else if (sceneInfo.dayCount >= 5 && isPrisoner == true)
       {
 
            SceneManager.LoadScene("PrisonEnding");
            DeactivateUpgradesMenu();
            Cursor.visible = true;
            sceneInfo.Reset();
       }
    }


    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
        DeactivateMenu();
        Cursor.visible = true;
        Time.timeScale = 1;
        
    }


    public void LoadData(GameData data)
    {
        sceneInfo.dayCount = data.playerAttributesData.dayCount;
    }

    public void SaveData(GameData data)
    {
        data.playerAttributesData.dayCount = sceneInfo.dayCount;
    }

}
