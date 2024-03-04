using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnerTesting : MonoBehaviour
{
    public GameObject NPC;
    public Transform Spawnpoint;
public void Spawn()
    {
        Instantiate(NPC, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);
    }
}
