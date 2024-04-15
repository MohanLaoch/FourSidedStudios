using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;

    public AttributesData playerAttributesData;

    public float currentTime;

    public GameData()
    {
        playerPosition = new Vector3(7, 1.2f, 1.5f);
        playerAttributesData = new AttributesData();
        currentTime = 180f;
    }
    
}
