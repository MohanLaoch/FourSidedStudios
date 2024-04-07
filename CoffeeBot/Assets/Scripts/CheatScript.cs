using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScript : MonoBehaviour
{
    // Declan's Cheat Variables

    [Header("Declan's Cheat Variables")]
    public bool declan;

    // James' Cheat Variables

    [Header("James' Cheat Variables")]
    public GameObject upgradesSelectionMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) && Input.GetKeyDown(KeyCode.Alpha9))
        {
            upgradesSelectionMenu.SetActive(true);
        }
    }

    // Declan's Cheat Functions

    void Declan()
    {

    }

    // James' Cheat Functions

}
