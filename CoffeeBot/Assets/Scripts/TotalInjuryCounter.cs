using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalInjuryCounter : MonoBehaviour
{
    public int totalInjuryCounter = 0;

    public NPCBarista npcBarista;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Warning()
    {
        npcBarista.Injury();
    }
}
