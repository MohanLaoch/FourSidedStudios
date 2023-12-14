using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerInputActions;
    [SerializeField] private InputAction menu;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
       
    }

    private void Update()
    {
        
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

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        //Audiolistener.pause = false;
        pauseUI.SetActive(false);
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
    }


}
