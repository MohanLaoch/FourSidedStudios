using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [Header("Storage Stats")]
    public int currentCapacity = 0;
    public int totalCapacity = 10;

    public int fillCapacity = 5;

    [Header("Items")]
    public string storedItem;

    public List<string> acceptedItems = new List<string>();
    public List<Sprite> acceptedItemSprites = new List<Sprite>();


    [Header("Sprites")]
    public Sprite currrentSprite;
    public Sprite nullSprite;

    public SpriteRenderer storageImage;

    private void Update()
    {
        // if the storage is at or below 0 it'll make storedItem null
        if (currentCapacity <= 0)
        {
            storedItem = null;
            storageImage.sprite = nullSprite;
        }

        // if the storge goes above current capacity bring it back down to the current (so no item overflow)
        if (currentCapacity > totalCapacity)
        {
            currentCapacity = totalCapacity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == storedItem)
        {
            currentCapacity += fillCapacity;
            Destroy(other.gameObject);
        }

        if (storedItem == null)
        {
            for (int i = 0; i < acceptedItems.Count; i++)
            {
                // if there is no stored item, store the current item. Using its tag as the name for the currently stored item

                // I do need to fix this so there isn't an and
                // also I need to make it so that if the item already matchs the current storedItem it'll just top up
                if (acceptedItems.Contains(other.gameObject.tag.ToString()))
                {
                    storedItem = other.gameObject.tag.ToString();
                    currentCapacity += fillCapacity;
                    Destroy(other.gameObject);
                }
                else
                {
                    // this "else" might not need to be here
                    return;
                }
            }
        }
    }

    public void EmptyStorage()
    {
        currentCapacity = 0;
        storedItem = null;
        storageImage.sprite = nullSprite;
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
