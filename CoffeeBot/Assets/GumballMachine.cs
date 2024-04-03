using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumballMachine : MonoBehaviour
{
    public bool GumballTime;
    public bool AtMachine;
    public Player player;

    public float GumballTimer;
    public float GumballCooldownTime;
    public bool MachineIsCooldown;
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
            if(MachineIsCooldown)
            {
                player.EPressed = false;
                return;
            }
            else
            {
                MachineIsCooldown = true;
                GumballTimer = GumballCooldownTime;
                
            }
         
            player.EPressed = false;
        }

        if(MachineIsCooldown)
        {
            ApplyMachineCooldown();
            GumballTime = true;
        }
        else
        {
            GumballTime = false;
        }


    }

    public void ApplyMachineCooldown()
    {
       GumballTimer -= Time.deltaTime;

        if(GumballTimer < 0.0f)
        {
            MachineIsCooldown = false;
            GumballTime = false;
        }
    }
}
