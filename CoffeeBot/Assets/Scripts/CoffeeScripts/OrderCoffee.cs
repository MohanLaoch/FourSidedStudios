using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class OrderCoffee : MonoBehaviour
{
    [Header("Script References")]

    public AvaliableOrders avaliableOrders;
    public Player player;
    public MoneyTracker moneyTracker;
    

    [Header("Coffee")]

    public string acceptedCoffeeTag;

    public Image coffeeImage;

    [Header("UI")]

    public TextMeshProUGUI coffeeText;

    public TextMeshProUGUI responseText;
    public GameObject responseBubble;
    public Image responseBubbleImage;

    public Slider timerBubble;

    private GameObject viewportContent;
    private GameObject orderText;

    [Header("Responses")]

    public string[] positiveResponses;
    public string[] negativeResponses;

    public Sprite positiveBubble;
    public Sprite negativeBubble;


    private void Awake()
    {
        // assign player script
        player = GameObject.Find("Sergio").GetComponent<Player>();
        avaliableOrders = GameObject.Find("UnlockCoffee").GetComponent<AvaliableOrders>();
        viewportContent = GameObject.Find("Content");

        responseBubble.SetActive(false);
        timerBubble.gameObject.SetActive(true);

        Order();

    }

    private void Order()
    {
        acceptedCoffeeTag = null;

        // choose a random string from coffeeOrders
        int randomIndex = Random.Range(0, avaliableOrders.coffeeOrders.Count);

        acceptedCoffeeTag = avaliableOrders.coffeeOrders[randomIndex];

        coffeeText.text = acceptedCoffeeTag;

        coffeeImage.sprite = avaliableOrders.orderIcons[randomIndex];

        orderText = avaliableOrders.orderListText[randomIndex];

        Instantiate(orderText, viewportContent.transform); 

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

        acceptedCoffeeTag = "";

        coffeeImage.gameObject.SetActive(false);

        // respond to getting coffee
        timerBubble.gameObject.SetActive(false);
        responseBubble.SetActive(true);

        if (!moneyTracker.upset)
        {
            responseBubbleImage.sprite = positiveBubble;

            int randomIndex = Random.Range(0, positiveResponses.Length);

            string randomResponse = positiveResponses[randomIndex];

            responseText.text = randomResponse;
        }
        else if (moneyTracker.upset)
        {
            responseBubbleImage.sprite = negativeBubble;

            int randomIndex = Random.Range(0, negativeResponses.Length);

            string randomResponse = negativeResponses[randomIndex];

            responseText.text = randomResponse;
        }


        GetComponent<NpcStateManager>().SwitchState(GetComponent<NpcStateManager>().leavingState);
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<NpcStateManager>().isLeaving = true;
        GetComponent<Animator>().SetBool("isWalking", true);
        GetComponent<Animator>().SetBool("isSitting", false);

        // go to the moneyTracker script and give money
        moneyTracker.CompleteOrder();

    }

    /* randomly order from a list of coffeeOrders - choose a random string, which will give us it's int 
     * search for the ordered coffee - change string of "acceptedCoffee" to the random string from coffeeOrders
     * if given acceptedCoffee complete order - ontrigger enter, if the coffee has the same tag as the string then finish the order
     */
}
