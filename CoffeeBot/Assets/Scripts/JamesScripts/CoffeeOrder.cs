using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoffeeOrder : MonoBehaviour
{
    public string coffeetag;

    [Header("Script References")]
    public MoneyTracker moneyTracker;

    /*[Header("GameObjects")]
    public GameObject coffee;
    public GameObject spawnObject;*/

    [Header("PlayerScript")]
    public Player player;

    [Header("Complete Order")]

    [SerializeField] private int secondsToWait = 5;

    [TextArea(3, 10)]
    public string[] orderResponses;

    public TextMeshProUGUI responseText;

    public GameObject timerBubble;
    public GameObject responseBubble;


    // Start is called before the first frame update
    void Awake()
    {
        Order();
    }

    void Order()
    {
        responseBubble.SetActive(false);

        timerBubble.SetActive(true);

        moneyTracker.StartTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the colliding object has the "coffeetag"

        if (other.gameObject.tag == coffeetag)
        {
            // destroy the "coffeetag" object & call CompleteOrder in the MoneyTracker script & create a new order

            //reset itemholding bool here
            player.Holding = false;
            Destroy(other.gameObject);
            moneyTracker.CompleteOrder();

            OrderResponse();
            
        }
    }

    void OrderResponse()
    {
        timerBubble.SetActive(false);

        responseBubble.SetActive(true);

        int randomIndex = Random.Range(0, orderResponses.Length);

        string randomResponse = orderResponses[randomIndex];

        responseText.text = randomResponse;

        StartCoroutine(NewOrder());
    }

    IEnumerator NewOrder()
    {
        yield return new WaitForSeconds(secondsToWait);

        Order();

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
