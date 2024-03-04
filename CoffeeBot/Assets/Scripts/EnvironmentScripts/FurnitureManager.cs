using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public GameObject[] chairs;
    public bool isSittable = true;
    public Transform door;
    public void SetChairs()
    {
        chairs = GameObject.FindGameObjectsWithTag("Chair");
    }
}
