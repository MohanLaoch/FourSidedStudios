using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public GameObject obj;

    private void OnMouseOver()
    {
        obj.SetActive(true);
    }

    private void OnMouseExit()
    {
        obj.SetActive(false);
    }
}
