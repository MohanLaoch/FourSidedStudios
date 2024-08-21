using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnerTesting : MonoBehaviour
{
    public GameObject NPC;
    public GameObject SRK;
    public Transform Spawnpoint;
    public int NpcSpawnTime = 10;
    public int NpcCount = 1;
    public int SRKChance;
    public SceneInfo sceneInfo;
    public NPCBarista nPCBarista;
    public void Start()
    {
        SRKChance = Random.Range(1, 10);
        Instantiate(NPC, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);

        if(sceneInfo.dayCount != 0)
        {
            StartCoroutine(SpawnNPC());
        }
    }

    public void Update()
    {
        switch(sceneInfo.dayCount)
        {
            case 1:
                NpcSpawnTime = 40;
                break;
            case 2:
                NpcSpawnTime = 35;
                break;
            case 3:
                NpcSpawnTime = 30;
                break;
            case 4:
                NpcSpawnTime = 25;
                break;
            case 5:
                NpcSpawnTime = 25;
                break;
        }
    }
    public IEnumerator SpawnNPC()
    {
        while(NpcCount < 7)
        {
            yield return new WaitForSeconds(NpcSpawnTime);
            SRKChance = Random.Range(1, 7);
            if(SRKChance < 6)
            {
                Instantiate(NPC, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);
                
            }
            else if(SRKChance >= 6 && sceneInfo.dayCount >= 2)
            {
                SpawnSRK();
                nPCBarista.Kid();
                //trigger warning method from barista :skull:
                //SRKChance = Random.Range(1, 7);
            }

            NpcCount++;
            
        }
       
    }

    public void SpawnSRK()
    {
        Instantiate(SRK, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);
    }



   /* public void Spawn()
    {
        Instantiate(NPC, new Vector3(Spawnpoint.position.x, Spawnpoint.position.y, Spawnpoint.position.z), Quaternion.identity);
    }*/
}
