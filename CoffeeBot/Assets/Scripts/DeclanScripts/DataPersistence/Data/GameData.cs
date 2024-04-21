using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public Vector3 tutorialPosition;
    public AttributesData playerAttributesData;

    

    public GameData()
    {
        playerPosition = new Vector3(7f, 1.2f, 1.563f);
        tutorialPosition = new Vector3(-4.37267f, 1.2f, -25.67498f);
        playerAttributesData = new AttributesData();
        
    }
    
}
