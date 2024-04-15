using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AttributesData
{
    public float money;

    public int dayCount;

    public float playerSpeed;

    public float playerRotSpeed;

    public float playerAcceleration;

    public float playerMaxThrowForce;

    public AttributesData()
    {
        money = 0;

        dayCount = 1;

        playerSpeed = 200;

        playerRotSpeed = 200;

        playerAcceleration = 10;

        playerMaxThrowForce = 10;
    }
}
