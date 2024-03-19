using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
{
    public string sceneName;
    public SceneInfo sceneInfo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Latte" || other.gameObject.tag == "Cappuccino")
        {
            SceneManager.LoadScene(sceneName);
            sceneInfo.Reset();
        }
    }
}
