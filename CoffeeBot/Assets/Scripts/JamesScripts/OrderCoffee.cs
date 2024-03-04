using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderCoffee : MonoBehaviour
{
    [Header("Script References")]

    public Player player;
    public MoneyTracker moneyTracker;

    [Header("Coffee")]

    public List<string> coffeeOrders = new List<string>();

    public string acceptedCoffeeTag;

    [Header("UI")]
    [TextArea(2, 5)]
    public string[] orderResponses;

    public TextMeshProUGUI responseText;
    public GameObject responseBubble;

    public GameObject timerBubble;


    private void Awake()
    {
        // assign player script
        player = GameObject.Find("CoffeeBotAnimated3").GetComponent<Player>();

        responseBubble.SetActive(false);
        timerBubble.SetActive(true);

        Order();

        moneyTracker.StartTimer();

    }

    private void Order()
    {
        acceptedCoffeeTag = null;

        // choose a random string from coffeeOrders
        int randomIndex = Random.Range(0, coffeeOrders.Count);

        acceptedCoffeeTag = coffeeOrders[randomIndex];

        // start the timer
        moneyTracker.StartTimer();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == acceptedCoffeeTag)
        {
            CompleteOrder();

            Destroy(other.gameObject);

            //reset itemholding bool here
            player.Holding = false;
        }
        else
            return; // code for rejecting an order can be put here
        
    }

    private void CompleteOrder()
    {
        // go to the moneyTracker script and give money
        moneyTracker.CompleteOrder();

        // respond to getting coffee
        timerBubble.SetActive(false);
        responseBubble.SetActive(true);

        int randomIndex = Random.Range(0, orderResponses.Length);

        string randomResponse = orderResponses[randomIndex];

        responseText.text = randomResponse;

    }

    /* randomly order from a list of coffeeOrders - choose a random string, which will give us it's int 
     * search for the ordered coffee - change string of "acceptedCoffee" to the random string from coffeeOrders
     * if given acceptedCoffee complete order - ontrigger enter, if the coffee has the same tag as the string then finish the order
     */
}
