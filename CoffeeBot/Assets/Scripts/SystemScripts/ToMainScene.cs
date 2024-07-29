using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ToMainScene : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    public string sceneName;
    public SceneInfo sceneInfo;

    public GameObject npcText;
    public GameObject npcTextMainScene;
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
        if (sceneInfo.dayCount != 0)
        {
            GetComponent<ToMainScene>().enabled = false;
        }
    }

    private void Start()
    {
        npcTextMainScene = GameObject.Find("BaristaText");

        action.performed += ctx => LoadNextScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(sceneInfo.dayCount == 0)
        {
            if (other.gameObject.tag == "Latte" || other.gameObject.tag == "Cappuccino" || other.gameObject.tag == "Americano")
            {
                Destroy(other.gameObject);
                canLoad = true;
                npcTextMainScene.GetComponent<Image>().enabled = true;
                npcTextMainScene.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            }
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
