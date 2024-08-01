using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour, IDataPersistence
{
    [SerializeField] private PlayerInputActions playerInputActions;
    [SerializeField] private CameraControls cameraControls;

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

    public Button CoffeeUnlock1;
    public Button CoffeeUnlock2;
    public Button CoffeeUnlock3;
    public Button CoffeeUnlock4;
    public Button CoffeeUnlock5;
    public Button CoffeeUnlock6;

    public Button UpgradeUnlock1;
    public Button UpgradeUnlock2;
    public Button UpgradeUnlock3;
    public Button UpgradeUnlock4;

    public Button UpgradesMenuButton;

    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton, upgradesFirstButton, endOfDayFirstButton, coffeeMenuFirstButton;

    public GameObject MainCamera;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    public void Start()
    {
        if(sceneInfo.ChaiLatteUnlocked)
        {
            CoffeeUnlock1.interactable = false;
        }
        if (sceneInfo.HotChocolateUnlocked)
        {
            CoffeeUnlock2.interactable = false;
        }
        if (sceneInfo.IcedCoffeeUnlocked)
        {
            CoffeeUnlock3.interactable = false;
        }
        if (sceneInfo.IcedLatteUnlocked)
        {
            CoffeeUnlock4.interactable = false;
        }
        if (sceneInfo.MochaUnlocked)
        {
            CoffeeUnlock5.interactable = false;
        }
        if (sceneInfo.TeaUnlocked)
        {
            CoffeeUnlock6.interactable = false;
        }

        if(sceneInfo.gumballMachineUnlocked)
        {
            UpgradeUnlock1.interactable = false;
        }
        if (sceneInfo.DashUnlocked)
        {
            UpgradeUnlock2.interactable = false;
        }
        if (sceneInfo.roboMopUnlocked)
        {
            UpgradeUnlock3.interactable = false;
        }
        if (sceneInfo.instaStockUnlocked)
        {
            UpgradeUnlock4.interactable = false;
        }

        if(sceneInfo.dayCount >= 5)
        {
            UpgradesMenuButton.interactable = false;
        }
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


        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        DisableCamera();

    }
    public void ActivateUpgradesMenu()
    {
        Time.timeScale = 0;
        //Audiolistener.pause = true;
        upgradeUI.SetActive(true);
        Cursor.visible = true;
        playerInputActions.Player.Disable();
        playerInputActions.Player.Flip.Disable();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(upgradesFirstButton);

        DisableCamera();
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
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(endOfDayFirstButton);

        DisableCamera();
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

        EnableCamera();
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
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(coffeeMenuFirstButton);

        EnableCamera();
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

        EnableCamera();


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

        EnableCamera();
    }

    public void DisableCamera()
    {
        MainCamera.GetComponent<Cinemachine.CinemachineInputProvider>().enabled = false;
    }

    public void EnableCamera()
    {
        MainCamera.GetComponent<Cinemachine.CinemachineInputProvider>().enabled = true;
    }



    public void ResetScene()
    {
        SceneManager.LoadScene("Prototype 1");
        Time.timeScale = 1;
        DeactivateMenu();

        sceneInfo.isNextScene = isNextScene;
          
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
        dayTimer.currentTime = 180f;
        sceneInfo.dayCount++;
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Prototype 1");
        
        Time.timeScale = 1;
        DeactivateMenu();
        DeactivateUpgradesMenu();

        dayTimer.EnableUI();
        
        
        
        
  
        if (sceneInfo.dayCount >= 6 && sceneInfo.money <= 50 && isPrisoner == false)
        {
            SceneManager.LoadScene("BadEnding");
            DeactivateMenu();
            DeactivateUpgradesMenu();
            Cursor.visible = true;
            sceneInfo.BadEndingAchieved = true;
            sceneInfo.Reset();
        }
        if (sceneInfo.dayCount >= 6 && sceneInfo.money > 50 && isPrisoner == false)
        {
            SceneManager.LoadScene("GoodEnding");
            DeactivateUpgradesMenu();
            Cursor.visible = true;
            sceneInfo.GoodEndingAchieved = true;
            sceneInfo.Reset();
        }
       else if (sceneInfo.dayCount >= 6 && isPrisoner == true)
       {
            
            SceneManager.LoadScene("PrisonEnding");
            DeactivateUpgradesMenu();
            Cursor.visible = true;
            sceneInfo.PrisonEndingAchieved = true;
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
