using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ToMainScene : MonoBehaviour
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

    private void Start()
    {
        action.performed += ctx => LoadNextScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Latte" || other.gameObject.tag == "Cappuccino")
        {
            Destroy(other.gameObject);
            canLoad = true;
            npcText.SetActive(true);
        }
    }

    private void LoadNextScene()
    {
        if (canLoad)
        {
            SceneManager.LoadScene(sceneName);
            sceneInfo.Reset();
            DataPersistenceManager.instance.NewGame();
        }
        else
            return;
    }


}
