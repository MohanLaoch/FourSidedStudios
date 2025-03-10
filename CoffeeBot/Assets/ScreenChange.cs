using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChange : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public GameObject ControllerScreen;
    public GameObject KeyboardScreen;

    private void Update()
    {
        if(sceneInfo.ControllerConnected)
        {
            ControllerScreen.SetActive(true);
            KeyboardScreen.SetActive(false);
        }
        else
        {
            ControllerScreen.SetActive(false);
            KeyboardScreen.SetActive(true);
        }
    }

}

