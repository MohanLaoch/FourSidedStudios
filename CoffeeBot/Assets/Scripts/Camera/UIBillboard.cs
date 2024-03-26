using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    public Transform camera;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
        
    }
}
