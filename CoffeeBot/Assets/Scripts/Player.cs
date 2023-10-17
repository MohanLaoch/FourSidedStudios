using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private TestingInputSystem testingInputSystem;


    private void Awake()
    {
      
    }

  
    void Start()
    {
        testingInputSystem.OnInteractAction += TestingInputSystem_OnInteractAction;

    }

    private void TestingInputSystem_OnInteractAction(object sender, System.EventArgs e)
    {
        
    }

    void Update()
    {
        
    }

    private void HandleInteractions()
    {

    }
}
