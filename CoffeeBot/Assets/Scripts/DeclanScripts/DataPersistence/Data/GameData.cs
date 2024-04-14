using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int dayCount;
    public float money;

    public GameData()
    {
        this.dayCount = 1;
        this.money = 0;
    }
    
}
