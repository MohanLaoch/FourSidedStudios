using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeOrder : MonoBehaviour
{
    public string coffeetag;

    [Header("Script References")]
    public MoneyTracker moneyTracker;

    [Header("GameObjects")]
    public GameObject coffee;
    public GameObject spawnObject;


    // Start is called before the first frame update
    void Awake()
    {
        Order();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Order()
    {
        Instantiate(coffee, new Vector3(spawnObject.transform.position.x, spawnObject.transform.position.y, spawnObject.transform.position.z), Quaternion.identity);
        moneyTracker.StartTimer();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == coffeetag)
        {
            Destroy(other.gameObject);
            moneyTracker.CompleteOrder();
            Order();
        }
    }

    /*
     * Coffee should be ordered like this for now
     * NPC is spawned in and using this CoffeeOrder script they order a coffee
     * For now a coffee is just spawned in and a timer starts to deliver it to the seating area
     * Once delievered the player gets an amount of money equal to how well they did compared to  60 seconds
     * 
     * 100 money for anything over 40
     * 50 money for anything under 40 but above 20
     * 25 for anything below 20
     * 
     * After money is given to the player a new npc will be spawned
     * (the previous one potentially removed)
     * 
     */
}
