using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftCoffee : MonoBehaviour
{

    [Header("Storage Units")]

    public Storage storageA;
    public Storage storageB;
    public Storage storageC;

    public int capacityRemoveAmount = 5;

    public List<string> storedItems = new List<string>();

    public string[] recipes;
    public GameObject[] recipieResults;
    
    // Update is called once per frame
    void Update()
    {
        storedItems[0] = storageA.itemName;
        storedItems[1] = storageB.itemName;
        storedItems[2] = storageC.itemName;

        CheckForCreatedRecipies();
    }

    void CheckForCreatedRecipies()
    {
        // make the currentRecipeString blank
        string currentRecipeString = "";

        // for every stored item...
        foreach (string storedItem in storedItems)
        {

            // if there is a stored item, add the name to the current recipe
            if(storedItem != null)
            {
                currentRecipeString += storedItem;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        // check all recipies 
        for (int i = 0; i < recipes.Length; i++)
        {
            // if the current recipe equals a craftable recipie, craft that recipe
            if(recipes[i] == currentRecipeString)
            {
                int currentRecipe = i;

                Vector3 spawnPos = this.transform.position;

                GameObject newCoffee = Instantiate(recipieResults[i], spawnPos, Quaternion.identity);

                EmptyCapacity();

                //spawn the coffee
                Debug.Log("I am HIM!");
            }
        }
    }

    void EmptyCapacity()
    {
        storageA.currentCapacity -= capacityRemoveAmount;
        storageB.currentCapacity -= capacityRemoveAmount;
        storageC.currentCapacity -= capacityRemoveAmount;
    }

}

/*
 * So I think the best way to do this is to take all the strings from each current Storage script
 * Do a check for those strings
 * If they are there make a coffee 
 * 
 * I want to make it so stored items are part of a list
 * and the crafting checker sees what items are in that list and if the list is equal to those items and it's a "recepie" it will craft
 */

/*
 * A RECEPIE SHOULD BE WRITTEN LIKE THIS:
 * if you want to craft a coffee which needs, CupBox, CoffeeBox and MilkBox
 * the recepie should be written as CupBox, CoffeeBox, and MilkBox
 */
