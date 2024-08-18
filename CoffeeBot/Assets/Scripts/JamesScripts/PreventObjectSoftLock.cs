using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventObjectSoftLock : MonoBehaviour
{

    public List<string> softLockObject = new List<string>();

    public GameObject player;

    public Player playerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (softLockObject.Contains(other.gameObject.tag.ToString()))
        {
            other.gameObject.transform.parent = null;

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            rb.constraints = RigidbodyConstraints.None;

            other.gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z - 1);

            playerScript.Holding = false;
        }
    }
}
