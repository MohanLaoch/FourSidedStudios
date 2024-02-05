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
    public int totalCapacity = 10;

    public int fillCapacity = 5;

    [Header("Items")]
    public string itemName;

    public List<string> acceptedItems = new List<string>();

    [Header("UI Components")]
    public TextMeshProUGUI storageText;

    //public List<Sprite> acceptedItemSprites = new List<Sprite>();


    /*[Header("Sprites")]
    public Sprite currrentSprite;
    public Sprite nullSprite;

    public SpriteRenderer storageImage;*/

    private bool atStorage;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        // if the storage is at or below 0 it'll make storedItem null
        if (currentCapacity <= 0)
        {
            itemName = null;
            //storageImage.sprite = nullSprite;
        }

        // if the storge goes above current capacity bring it back down to the current (so no item overflow)
        if (currentCapacity > totalCapacity)
        {
            currentCapacity = totalCapacity;
        }

        // for emptying the storage
        if (atStorage)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EmptyStorage();
            }
        }

        storageText.text = itemName + " " + currentCapacity.ToString();
;    }

    private void OnTriggerEnter(Collider other)
    {

        /*if (other.gameObject.tag == "Player") 
        {
            EmptyStorage();
        }*/

        if (other.gameObject.CompareTag("Player"))
        {
            atStorage = true;
        }


        if (other.gameObject.tag == itemName)
        {
            currentCapacity += fillCapacity;
            
        }

        if (itemName == null)
        {
            for (int i = 0; i < acceptedItems.Count; i++)
            {
                // if there is no stored item, store the current item. Using its tag as the name for the currently stored item

                // I do need to fix this so there isn't an and
                // also I need to make it so that if the item already matchs the current storedItem it'll just top up
                if (acceptedItems.Contains(other.gameObject.tag.ToString()))
                {
                    itemName = other.gameObject.tag.ToString();
                    currentCapacity += fillCapacity;
                    
                }
                else
                {
                    // this "else" might not need to be here
                    return;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            atStorage = false;
        }
    }

    public void EmptyStorage()
    {
        currentCapacity = 0;
        itemName = null;
        //storageImage.sprite = nullSprite;
    }

}
/*
 * WHEN ADDING A NEW ACCEPTED ITEM PLEASE CREATE A TAG WITH THE EXACT SAME NAME!!!
 * ACCEPTED ITEMS AND TAGS SHOULD BE WRITTEN AS FOLLOWS:
 * 
 * If the item is a box of coffee, its tag should be - CoffeeBox
 */


/*
 * so currently the system can add an item from the list if storage is empty, but it doesn't let you refill
 * so I need to add that function
 * there's also letting you empty it maybe?
 * what else???? store an item, refill, empty... 
 * 
 * SPRITES that's what it was 
 */
