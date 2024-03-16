using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnerTesting : MonoBehaviour
{
    public GameObject NPC;
    public Transform Spawnpoint;
    public int NpcSpawnTime = 10;
    public int NpcCount = 1;
    public void Start()
    {
        StartCoroutine(SpawnNPC());
    }

    public void Update()
    {

    }
    public IEnumerator SpawnNPC()
    {
        while(NpcCount < 10)
        {
            yield return new WaitForSeconds(NpcSpawnTime);
            Instantiate(NPC, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);
            NpcCount++;            
        }
       
    }



   /* public void Spawn()
    {
        Instantiate(NPC, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);
    }*/
}
