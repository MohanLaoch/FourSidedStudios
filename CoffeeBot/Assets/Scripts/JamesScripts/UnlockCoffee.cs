using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCoffee : MonoBehaviour
{
    // Player starts off being able to make an Americano, a Cappuccino, and a Latte

    public CraftCoffee craftCoffee;
    public AvaliableOrders avaliableOrders;

    [Header("Storage Boxes")]
    public GameObject cocoPowder;
    public GameObject ice;
    public GameObject teaBags;

    [Header("Spawn Areas")]
    public Transform cocoPowderSpawn;
    public Transform iceSpawn;
    public Transform teaBagsSpawn;


    [HideInInspector]
    public bool hasCocoPowder;
    [HideInInspector]
    public bool hasIce;
    [HideInInspector]
    public bool hasTeaBags;

    [Header("Coffee Prefabs")]

    public GameObject chaiLatte;
    public Sprite chaiLatteSprite;

    public GameObject hotChocolate;
    public Sprite hotChocolateSprite;

    public GameObject icedCoffee;
    public Sprite icedCoffeeSprite;

    public GameObject icedLatte;
    public Sprite icedLatteSprite;

    public GameObject mocha;
    public Sprite mochaSprite;

    public GameObject tea;
    public Sprite teaSprite;

    public void UnlockChaiLatte()
    {
        craftCoffee.recipes.Add("MilkTeaBagsNull");
        craftCoffee.recipes.Add("MilkNullTeaBags");
        craftCoffee.recipes.Add("TeaBagsMilkNull");
        craftCoffee.recipes.Add("TeaBagsNullMilk");
        craftCoffee.recipes.Add("NullMilkTeaBags");
        craftCoffee.recipes.Add("NullTeaBagsMilk");

        craftCoffee.recipeResults.Add(chaiLatte);
        craftCoffee.recipeResults.Add(chaiLatte);
        craftCoffee.recipeResults.Add(chaiLatte);
        craftCoffee.recipeResults.Add(chaiLatte);
        craftCoffee.recipeResults.Add(chaiLatte);
        craftCoffee.recipeResults.Add(chaiLatte);

        if (!hasTeaBags)
        {
            Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
            hasTeaBags = true;
        }

        avaliableOrders.coffeeOrders.Add("ChaiLatte");
        avaliableOrders.orderIcons.Add(chaiLatteSprite);
            
    }

    public void UnlockHotChocolate()
    {
        craftCoffee.recipes.Add("MilkCocoPowderNull");
        craftCoffee.recipes.Add("MilkNullCocoPowder");
        craftCoffee.recipes.Add("CocoPowderMilkNull");
        craftCoffee.recipes.Add("CocoPowderNullMilk");
        craftCoffee.recipes.Add("NullMilkCocoPowder");
        craftCoffee.recipes.Add("NullCocoPowderMilk");

        craftCoffee.recipeResults.Add(hotChocolate);
        craftCoffee.recipeResults.Add(hotChocolate);
        craftCoffee.recipeResults.Add(hotChocolate);
        craftCoffee.recipeResults.Add(hotChocolate);
        craftCoffee.recipeResults.Add(hotChocolate);
        craftCoffee.recipeResults.Add(hotChocolate);

        if (!hasCocoPowder)
        {
            Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
            hasCocoPowder = true;
        }

        avaliableOrders.coffeeOrders.Add("HotChocolate");
        avaliableOrders.orderIcons.Add(hotChocolateSprite);
    }

    public void UnlockIcedCoffee()
    {
        craftCoffee.recipes.Add("IceCoffeeBeansWater");
        craftCoffee.recipes.Add("IceWaterCoffeeBeans");
        craftCoffee.recipes.Add("CoffeeBeansIceWater");
        craftCoffee.recipes.Add("CoffeeBeansWaterIce");
        craftCoffee.recipes.Add("WaterIceCoffeeBeans");
        craftCoffee.recipes.Add("WaterCoffeeBeansIce");

        craftCoffee.recipeResults.Add(icedCoffee);
        craftCoffee.recipeResults.Add(icedCoffee);
        craftCoffee.recipeResults.Add(icedCoffee);
        craftCoffee.recipeResults.Add(icedCoffee);
        craftCoffee.recipeResults.Add(icedCoffee);
        craftCoffee.recipeResults.Add(icedCoffee);

        if (!hasIce)
        {
            Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
            hasIce = true;
        }

        avaliableOrders.coffeeOrders.Add("IcedCoffee");
        avaliableOrders.orderIcons.Add(icedCoffeeSprite);
    }

    public void UnlockIcedLatte()
    {
        craftCoffee.recipes.Add("MilkCoffeeBeansIce");
        craftCoffee.recipes.Add("MilkIceCoffeeBeans");
        craftCoffee.recipes.Add("CoffeeBeansMilkIce");
        craftCoffee.recipes.Add("CoffeeBeansIceMilk");
        craftCoffee.recipes.Add("IceMilkCoffeeBeans");
        craftCoffee.recipes.Add("IceCoffeeBeansMilk");

        craftCoffee.recipeResults.Add(icedLatte);
        craftCoffee.recipeResults.Add(icedLatte);
        craftCoffee.recipeResults.Add(icedLatte);
        craftCoffee.recipeResults.Add(icedLatte);
        craftCoffee.recipeResults.Add(icedLatte);
        craftCoffee.recipeResults.Add(icedLatte);

        if (!hasIce)
        {
            Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
            hasIce = true;
        }

        avaliableOrders.coffeeOrders.Add("IcedLatte");
        avaliableOrders.orderIcons.Add(icedLatteSprite);
    }

    public void UnlockMocha()
    {
        craftCoffee.recipes.Add("MilkCoffeeBeansCocoPowder");
        craftCoffee.recipes.Add("MilkCocoPowderCoffeeBeans");
        craftCoffee.recipes.Add("CoffeeBeansMilkCocoPowder");
        craftCoffee.recipes.Add("CoffeeBeansCocoPowderMilk");
        craftCoffee.recipes.Add("CocoPowderMilkCoffeeBeans");
        craftCoffee.recipes.Add("CocoPowderCoffeeBeansMilk");

        craftCoffee.recipeResults.Add(mocha);
        craftCoffee.recipeResults.Add(mocha);
        craftCoffee.recipeResults.Add(mocha);
        craftCoffee.recipeResults.Add(mocha);
        craftCoffee.recipeResults.Add(mocha);
        craftCoffee.recipeResults.Add(mocha);

        if (!hasCocoPowder)
        {
            Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
            hasCocoPowder = true;
        }

        avaliableOrders.coffeeOrders.Add("Mocha");
        avaliableOrders.orderIcons.Add(mochaSprite);

    }

    public void UnlockTea()
    {
        craftCoffee.recipes.Add("MilkWaterTeaBags");
        craftCoffee.recipes.Add("MilkTeaBagsWater");
        craftCoffee.recipes.Add("WaterMilkTeaBags");
        craftCoffee.recipes.Add("WaterTeaBagsMilk");
        craftCoffee.recipes.Add("TeaBagsMilkWater");
        craftCoffee.recipes.Add("TeaBagsWaterMilk");

        craftCoffee.recipeResults.Add(tea);
        craftCoffee.recipeResults.Add(tea);
        craftCoffee.recipeResults.Add(tea);
        craftCoffee.recipeResults.Add(tea);
        craftCoffee.recipeResults.Add(tea);
        craftCoffee.recipeResults.Add(tea);

        if (!hasTeaBags)
        {
            Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
            hasTeaBags = true;
        }

        avaliableOrders.coffeeOrders.Add("Tea");
        avaliableOrders.orderIcons.Add(teaSprite);
    }
}

/*
 * When unlocking a new coffee a button will be pressed to call the function
 * the function needs to do the following:
 * - add any needed ingredients storage
 * - add the new recipies to the "recipies" string
 * - add the new gameobject to "recipieResults"
 * - add the option for the NPCs to order the coffee
 */
