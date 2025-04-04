using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Storage : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerInputActions;

    [Header("Storage Stats")]
    public int currentCapacity = 0;
    public int totalCapacity = 0;
    public int maxCapacity = 5;

    [SerializeField] private int fillCapacity = 1;

    [Header("Items")]
    public string itemName;

    public List<string> acceptedItems = new List<string>();

    [Header("UI Components")]
    public GameObject indicatorText;
    public TextMeshProUGUI storageText;
    public TextMeshProUGUI buttonText;
    public Sprite buttonY;
    public Sprite buttonB;
    public Image controllerButton;
    public Image storageImage;

    [Header("Sprites")]
    public List<Sprite> acceptedItemSprites = new List<Sprite>();

    public Sprite currrentSprite;
    public Sprite nullSprite;

    [Header("Bools")]

    public bool atStorage;

    public bool husband = false;

    public SceneInfo sceneInfo;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Empty.performed += EmptyStorage;


    }

    private void Update()
    {
        if(sceneInfo.instaStockUnlocked)
        {
          fillCapacity = maxCapacity;
        }
        
        maxCapacity = sceneInfo.storageMax;
        // if the storage is at or below 0 it'll make storedItem null
        if (currentCapacity <= 0)
        {
            currentCapacity = 0;
            totalCapacity = 0;
            itemName = null;
            storageImage.sprite = nullSprite;
            buttonText.text = "E".ToString();
            controllerButton.sprite = buttonY;
        }

        // if the storge goes above current capacity bring it back down to the current (so no item overflow)
        if (currentCapacity > totalCapacity)
        {
            currentCapacity = totalCapacity;
        }

        if (totalCapacity > maxCapacity)
        {
            totalCapacity = maxCapacity;
        }

        // for emptying the storage
        if (atStorage)
        {
            indicatorText.SetActive(true);
            /*if (Input.GetKeyDown(KeyCode.F))
            {
                EmptyStorage();
            }*/

        }
        else if (!atStorage)
        {
            indicatorText.SetActive(false);
        }

        storageText.text = /*itemName + " " + */ currentCapacity + "/" + maxCapacity.ToString();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            atStorage = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            atStorage = true;
        }

        // if an item is already in the storage and you come with the same item. It will add another of that item
        if (other.gameObject.tag == itemName)
        {
            currentCapacity += fillCapacity;

        }

        if (husband == true)
        {
            // if an item is already in the storage and you come with the same item. It will add another of that item
            if (other.gameObject.tag == itemName)
            {
                AddStorage();

            }

            if (itemName == null)
            {
                // if there is no stored item, store the current item. Using its tag as the name for the currently stored item

                // I do need to fix this so there isn't an and
                // also I need to make it so that if the item already matchs the current storedItem it'll just top up
                if (acceptedItems.Contains(other.gameObject.tag.ToString()))
                {
                    int currentNumber = acceptedItems.IndexOf(other.gameObject.tag);

                    currrentSprite = acceptedItemSprites[currentNumber];

                    storageImage.sprite = currrentSprite;

                    buttonText.text = "F".ToString();
                    controllerButton.sprite = buttonB;

                    itemName = other.gameObject.tag.ToString();

                    AddStorage();

                }
                else
                    return;


            }
        }
        
    }

    public void AddStorage()
    {
        husband = false;
        currentCapacity += fillCapacity;
        totalCapacity += fillCapacity;

    }


    public void EmptyStorage(InputAction.CallbackContext context)
    {
        if(context.performed && atStorage)
        {
            currentCapacity = 0;
            totalCapacity = 0;
            itemName = null;
            storageImage.sprite = nullSprite;
            buttonText.text = "E".ToString();
        }


    }
}
/*
 * WHEN ADDING A NEW ACCEPTED ITEM PLEASE CREATE A TAG WITH THE EXACT SAME NAME!!!
 * ACCEPTED ITEMS AND TAGS SHOULD BE WRITTEN AS FOLLOWS:
 * 
 * If the item is a box of coffee beans, its tag should be - CoffeeBeans
 */


/*
 * so currently the system can add an item from the list if storage is empty, but it doesn't let you refill
 * so I need to add that function
 * there's also letting you empty it maybe?
 * what else???? store an item, refill, empty... 
 * 
 * SPRITES that's what it was 
 */
