using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnerTesting : MonoBehaviour
{
    public GameObject NPC;
    public Transform Spawnpoint;
public void Spawn()
    {
        Instantiate(NPC, Spawnpoint);
    }
}
