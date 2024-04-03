using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumballMachine : MonoBehaviour
{
    public bool GumballTime;
    public bool AtMachine;
    public Player player;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AtMachine = true;
        }
    }

    public void Update()
    {
        if(AtMachine && player.EPressed)
        {
            GumballTime = true;
            player.EPressed = false;
        }
    }
}
