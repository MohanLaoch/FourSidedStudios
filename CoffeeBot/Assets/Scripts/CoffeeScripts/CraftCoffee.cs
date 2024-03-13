using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftCoffee : MonoBehaviour
{

    [Header("Storage Units")]

    public Storage storageA;
    public Storage storageB;
    public Storage storageC;

    public List<string> storedItems = new List<string>();

    [Header("StartingCoffee")]

    public GameObject americano;
    public GameObject cappuccino;
    public GameObject latte;

    
    public List<string> recipes = new List<string>();
    
    public List<GameObject> recipeResults = new List<GameObject>();


    [Header("Ability to Craft")]

    public int secondsToWait = 1;

    [SerializeField] private int capacityRemoveAmount = 1;

    private bool canCraft = true;

    private void Start()
    {
        // Americano

        recipes.Add("WaterCoffeeBeansNull");
        recipes.Add("WaterNullCoffeeBeans");
        recipes.Add("CoffeeBeansWaterNull");
        recipes.Add("CoffeeBeansNullWater");
        recipes.Add("NullWaterCoffeeBeans");
        recipes.Add("NullWaterCoffeeBeans");

        recipeResults.Add(americano);
        recipeResults.Add(americano);
        recipeResults.Add(americano);
        recipeResults.Add(americano);
        recipeResults.Add(americano);
        recipeResults.Add(americano);

        //Cappuccino

        recipes.Add("MilkMilkCoffeeBeans");
        recipes.Add("MilkCoffeeBeansMilk");
        recipes.Add("CoffeeBeansMilkMilk");

        recipeResults.Add(cappuccino);
        recipeResults.Add(cappuccino);
        recipeResults.Add(cappuccino);

        //Latte

        recipes.Add("MilkCoffeeBeansNull");
        recipes.Add("MilkNullCoffeeBeans");
        recipes.Add("CoffeeBeansMilkNull");
        recipes.Add("CoffeeBeansNullMilk");
        recipes.Add("NullMilkCoffeeBeans");
        recipes.Add("NullCoffeeBeansMilk");

        recipeResults.Add(latte);
        recipeResults.Add(latte);
        recipeResults.Add(latte);
        recipeResults.Add(latte);
        recipeResults.Add(latte);
        recipeResults.Add(latte);
    }

    // Update is called once per frame
    void Update()
    {
        storedItems[0] = storageA.itemName;
        storedItems[1] = storageB.itemName;
        storedItems[2] = storageC.itemName;

        
    }

    public void CheckForCreatedRecipies()
    {
        if (canCraft)
        {
            StartCoroutine(CreateCoffee());

        }
        else
            return;
    }

    IEnumerator CreateCoffee()
    {
        canCraft = false;

        // make the currentRecipeString blank
        string currentRecipeString = "";

        // for every stored item...
        foreach (string storedItem in storedItems)
        {

            // if there is a stored item, add the name to the current recipe
            if (storedItem != null)
            {
                currentRecipeString += storedItem;
            }
            else
            {
                currentRecipeString += "Null";
            }
        }

        // check all recipies 
        for (int i = 0; i < recipes.Count; i++)
        {
            // if the current recipe equals a craftable recipie, craft that recipe
            if (recipes[i] == currentRecipeString)
            {
                int currentRecipe = i;

                Vector3 spawnPos = this.transform.position;

                //spawn the coffee
                GameObject newCoffee = Instantiate(recipeResults[i], spawnPos, Quaternion.identity);

                EmptyCapacity();
            }
        }

        yield return new WaitForSeconds(secondsToWait);

        canCraft = true;


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
 * if you want to craft a Latte which needs, Milk, CoffeeBeans and Null
 * the recepie should be written as MilkCoffeeBeansNull
 */
