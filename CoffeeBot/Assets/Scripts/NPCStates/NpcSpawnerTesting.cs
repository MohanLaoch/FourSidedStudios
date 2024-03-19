using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnerTesting : MonoBehaviour
{
    public GameObject NPC;
    public Transform Spawnpoint;
    public int NpcSpawnTime = 10;
    public int NpcCount = 1;

    public SceneInfo sceneInfo;
    public void Start()
    {
        Instantiate(NPC, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);
        StartCoroutine(SpawnNPC());
    }

    public void Update()
    {
        switch(sceneInfo.dayCount)
        {
            case 1:
                NpcSpawnTime = 40;
                break;
            case 2:
                NpcSpawnTime = 30;
                break;
            case 3:
                NpcSpawnTime = 25;
                break;
            case 4:
                NpcSpawnTime = 20;
                break;
            case 5:
                NpcSpawnTime = 15;
                break;
        }
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
