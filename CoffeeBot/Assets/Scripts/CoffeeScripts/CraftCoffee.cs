using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class CraftCoffee : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    [Header("Storage Units")]

    public Storage storageA;
    public Storage storageB;
    public Storage storageC;

    public List<string> storedItems = new List<string>();

    [Header("StartingCoffee")]

    public GameObject americano;
    public GameObject cappuccino;
    public GameObject latte;

    
    [HideInInspector]
    public List<string> recipes = new List<string>();

    [HideInInspector]
    public List<GameObject> recipeResults = new List<GameObject>();  

    public List<string> falseRecipes = new List<string>();


    [Header("Ability to Craft")]

    public int secondsToWait = 1;

    [SerializeField] 
    private int capacityRemoveAmount = 1;

    private bool canCraft = true;

    [Header("About to be Crafted")]
    public Image coffeeCraftImage;
    public TMP_Text coffeeCraftText;

    [HideInInspector]
    public List<string> recipeNames = new List<string>();

    public Sprite americanoSprite;
    public Sprite cappuccinoSprite;
    public Sprite latteSprite;
    public Sprite nullSprite;

    [HideInInspector]
    public List<Sprite> recipeImages = new List<Sprite>();

    private void Awake()
    {
        // Americano

        recipes.Add("WaterCoffeeBeansNull");
        recipes.Add("WaterNullCoffeeBeans");
        recipes.Add("CoffeeBeansWaterNull");
        recipes.Add("CoffeeBeansNullWater");
        recipes.Add("NullWaterCoffeeBeans");
        //recipes.Add("NullWaterCoffeeBeans");

        for (int i = 0; i < 6; i++)
        {
            recipeResults.Add(americano);

            recipeImages.Add(americanoSprite);

            recipeNames.Add("Americano");

        }

        //Cappuccino

        recipes.Add("MilkMilkCoffeeBeans");
        recipes.Add("MilkCoffeeBeansMilk");
        recipes.Add("CoffeeBeansMilkMilk");

        for (int i = 0; i < 3; i++)
        {
            recipeResults.Add(cappuccino);

            recipeImages.Add(cappuccinoSprite);

            recipeNames.Add("Cappuccino");

        }

        //Latte

        recipes.Add("MilkCoffeeBeansNull");
        recipes.Add("MilkNullCoffeeBeans");
        recipes.Add("CoffeeBeansMilkNull");
        recipes.Add("CoffeeBeansNullMilk");
        recipes.Add("NullMilkCoffeeBeans");
        recipes.Add("NullCoffeeBeansMilk");

        for (int i = 0; i < 6; i++)
        {
            recipeResults.Add(latte);

            recipeImages.Add(latteSprite);

            recipeNames.Add("Latte");
        }
    }

    private void Start()
    {
        action.performed += ctx => CheckForCreatedRecipies();

    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        storedItems[0] = storageA.itemName;
        storedItems[1] = storageB.itemName;
        storedItems[2] = storageC.itemName;

        UpdateCoffeeImage();
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
                coffeeCraftImage.sprite = nullSprite;
                coffeeCraftText.text = "?".ToString();
            }
        }


        // check all recipies 
        for (int i = 0; i < recipes.Count; i++)
        {
            // if the current recipe equals a craftable recipie, craft that recipe
            if (recipes[i] == currentRecipeString)
            {               

                Vector3 spawnPos = this.transform.position;

                //spawn the coffee
                GameObject newCoffee = Instantiate(recipeResults[i], spawnPos, Quaternion.identity);

                EmptyCapacity();
            }
        }

        yield return new WaitForSeconds(secondsToWait);

        canCraft = true;


    }

    public void UpdateCoffeeImage()
    {
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
                coffeeCraftImage.sprite = nullSprite;
                coffeeCraftText.text = "?".ToString();
            }
        }

        // check all recipies 
        for (int i = 0; i < recipes.Count; i++)
        {
            // if the current recipe equals a craftable recipe, show the sprite of the recipe
            if (recipes[i] == currentRecipeString)
            {

                coffeeCraftImage.sprite = recipeImages[i];
                coffeeCraftText.text = recipeNames[i];

            }
            
        }

        for (int i = 0; i < falseRecipes.Count; i++)
        {
            if (falseRecipes[i] == currentRecipeString)
            {

                coffeeCraftImage.sprite = nullSprite;
                coffeeCraftText.text = "?".ToString();

            }
        }
    }

    void EmptyCapacity()
    {
        storageA.currentCapacity -= capacityRemoveAmount;
        storageB.currentCapacity -= capacityRemoveAmount;
        storageC.currentCapacity -= capacityRemoveAmount;

        storageA.totalCapacity -= capacityRemoveAmount;
        storageB.totalCapacity -= capacityRemoveAmount;
        storageC.totalCapacity -= capacityRemoveAmount;

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
