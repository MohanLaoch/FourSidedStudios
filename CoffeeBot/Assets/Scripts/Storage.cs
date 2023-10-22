using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public int currentCapacity = 0;
    public int totalCapacity = 10;

    public string storedItem;

    public List<string> acceptedItems = new List<string>();

    private void Update()
    {
        if (currentCapacity <= 0)
        {
            storedItem = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < acceptedItems.Count; i++)
        {
            // if there is no stored item, store the current item. Using its tag as the name for the currently stored item

            // I do need to fix this so there isn't an and
            // also I need to make it so that if the item already matchs the current storedItem it'll just top up
            if (acceptedItems.Contains(other.gameObject.tag.ToString()) && storedItem == null)
            {
                storedItem = other.gameObject.tag.ToString();
            }
        }
    }

}
