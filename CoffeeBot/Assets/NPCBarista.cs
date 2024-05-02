using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBarista : MonoBehaviour
{
    public TotalInjuryCounter totalInjuryCounter;

    public GameObject injuryWarning;
    public GameObject kidWarning;

    public GameObject viewportContent;

    private bool canSpawn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SugarRushKid" && canSpawn)
        {
            canSpawn = false;
            Instantiate(kidWarning, viewportContent.transform);

            StartCoroutine(Wait());
        }
    }

    public void Injury()
    {
        if (totalInjuryCounter.totalInjuryCounter >= 5)
        {
            Instantiate(injuryWarning, viewportContent.transform);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        canSpawn = true;
    }
}
