using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SergioRotate : MonoBehaviour
{
    public float RotSpeed = 50f;
    void Update()
    {
        transform.Rotate(Vector3.up * RotSpeed * Time.deltaTime);
    }
}
