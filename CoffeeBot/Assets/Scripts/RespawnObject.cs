using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public GameObject fallenObject;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        fallenObject = other.gameObject;

        Instantiate(fallenObject, new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z), Quaternion.identity);

        fallenObject = null;

    }
}
