using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int dayCount;

    public float money;

    public int testing;

    public Vector3 playerPosition;

    public GameData()
    {
        this.dayCount = 1;
        this.money = 0;
        testing = 0;
        playerPosition = new Vector3(7, 1.2f, 1.5f);
    }
    
}
