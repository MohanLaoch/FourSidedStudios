using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject obj;

    public void OnPointerEnter(PointerEventData evenData)
    {
        obj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData evenData)
    {
        obj.SetActive(false);
    }

}
