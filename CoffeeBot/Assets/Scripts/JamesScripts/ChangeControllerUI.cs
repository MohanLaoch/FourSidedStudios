using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControllerUI : MonoBehaviour
{
    public SceneInfo sceneInfo;

    public GameObject keyboardUI;
    public GameObject controllerUI;

    private void Update()
    {
        if (!sceneInfo.ControllerConnected)
        {
            keyboardUI.SetActive(true);
            controllerUI.SetActive(false);
        }
        else 
        {
            keyboardUI.SetActive(false);
            controllerUI.SetActive(true);
        }
    }
}
