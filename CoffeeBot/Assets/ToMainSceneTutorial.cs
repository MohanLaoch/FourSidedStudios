using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ToMainSceneTutorial : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    public string sceneName;
    public SceneInfo sceneInfo;

    public GameObject npcText;
    private bool canLoad = false;


    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
    public void Awake()
    {

    }

    private void Start()
    {
        action.performed += ctx => LoadNextScene();
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Latte" || other.gameObject.tag == "Cappuccino")
        {
            npcText.gameObject.SetActive(true);
            Destroy(other.gameObject);
            canLoad = true;
        }
    }

    private void LoadNextScene()
    {
        if (canLoad)
        {
            DataPersistenceManager.instance.NewGame();
            sceneInfo.Reset();
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene(sceneName);
            sceneInfo.dayCount = 0;


        }
        else
            return;
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene(sceneName);
        sceneInfo.Reset();
        DataPersistenceManager.instance.NewGame();
    }


}
