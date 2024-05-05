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
        if (gameObject.tag == "NPC")
        {
            fallenObject = null;
        }
        else
        {
            fallenObject = other.gameObject;

            Instantiate(fallenObject, new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z - 2), Quaternion.identity);

            fallenObject = null;
        }

    }
}
