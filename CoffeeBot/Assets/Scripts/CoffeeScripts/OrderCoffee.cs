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
    public SceneInfo sceneInfo;

    [Header("Coffee")]

    public string acceptedCoffeeTag;

    public Image coffeeImage;

    public int coffeeCost;

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

    private GameObject orderGameObject;

    private void Awake()
    {
        // assign player script
        player = FindObjectOfType<Player>();
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

        orderGameObject = (GameObject)Instantiate(orderText, viewportContent.transform);

        coffeeCost = avaliableOrders.orderCost[randomIndex];

        // start the timer
        moneyTracker.StartTimer();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == acceptedCoffeeTag)
        {
            Destroy(other.gameObject);
            CompleteOrder();
            other.gameObject.transform.Find("HighlightRing").transform.parent = player.transform;                      
            
            //reset itemholding bool here
            player.Holding = false;
        }
        else if(other.gameObject.tag != acceptedCoffeeTag)
        {
            return;
        }
            //return; // code for rejecting an order can be put here
        
    }

    private void CompleteOrder()
    {
        //Destroy(orderGameObject);


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

        if(sceneInfo.dayCount != 0)
        {
         GetComponent<NpcStateManager>().SwitchState(GetComponent<NpcStateManager>().leavingState);
        }
        //activate colliders again
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<NpcStateManager>().isLeaving = true;
        GetComponent<Animator>().SetBool("isWalking", true);
        GetComponent<Animator>().SetBool("isSitting", false);

        // go to the moneyTracker script and give money

        moneyTracker.moneyGiven = coffeeCost;

        moneyTracker.CompleteOrder();

        player.Holding = false;

        Destroy(orderGameObject); // removes the Order from the order list (DO NOT DELETE)
        
    }

    public void NoOrder()
    {
        responseBubbleImage.sprite = negativeBubble;

        int randomIndex = Random.Range(0, negativeResponses.Length);

        string randomResponse = negativeResponses[randomIndex];

        responseText.text = randomResponse;
    }

    /* randomly order from a list of coffeeOrders - choose a random string, which will give us it's int 
     * search for the ordered coffee - change string of "acceptedCoffee" to the random string from coffeeOrders
     * if given acceptedCoffee complete order - ontrigger enter, if the coffee has the same tag as the string then finish the order
     */
}
