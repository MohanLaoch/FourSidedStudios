using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public Vector3 tutorialPosition;
    public AttributesData playerAttributesData;

    public float hSense;
    public float vSense;

    public float volumeSliderValue;

    

    public GameData()
    {
        playerPosition = new Vector3(2f, 1.2f, -5f);
        tutorialPosition = new Vector3(-4.37267f, 1.2f, -25.67498f);
        hSense = 125;
        vSense = 125;
        volumeSliderValue = 1;
        playerAttributesData = new AttributesData();
        
    }
    
}
