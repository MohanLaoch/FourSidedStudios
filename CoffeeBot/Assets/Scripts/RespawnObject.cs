using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public List<string> ignoreTags = new List<string>();

    public GameObject fallenObject;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ignoreTags.Contains(other.gameObject.tag.ToString()))
        {
            Destroy(other.gameObject);
        }
        else
        {
            fallenObject = other.gameObject;

            Instantiate(fallenObject, new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z - 2), Quaternion.identity);

            fallenObject = null;
        }

    }
}
