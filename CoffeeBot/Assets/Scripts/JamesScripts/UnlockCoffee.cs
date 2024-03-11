using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCoffee : MonoBehaviour
{
    // Player starts off being able to make an Americano, a Cappuccino, and a Latte

    public CraftCoffee craftCoffee;
    public OrderCoffee orderCoffee;

    public GameObject cocoPowder;
    public GameObject ice;
    public GameObject teaBags;

    public Transform cocoPowderSpawn;
    public Transform iceSpawn;
    public Transform teaBagsSpawn;


    [HideInInspector]
    public bool hasCocoPowder;
    public bool hasIce;
    public bool hasTeaBags;

    private int amount = 6;

    [Header("Chai Latte")]

    public GameObject chaiLatte;

    [Header("Hot Chocolate")]

    public GameObject hotChocolate;

    [Header("Iced Coffee")]

    public GameObject icedCoffee;

    [Header("Iced Latte")]

    public GameObject icedLatte;

    [Header("Mocha")]

    public GameObject mocha;

    [Header("Tea")]

    public GameObject tea;

    public void UnlockChaiLatte()
    {
        craftCoffee.recipes.Add("MilkTeaBagsNull");
        craftCoffee.recipes.Add("MilkNullTeaBags");
        craftCoffee.recipes.Add("TeaBagsMilkNull");
        craftCoffee.recipes.Add("TeaBagsNullMilk");
        craftCoffee.recipes.Add("NullMilkTeaBags");
        craftCoffee.recipes.Add("NullTeaBagsMilk");

        for (int i = amount; i == amount; i++ )
        {
            craftCoffee.recipeResults.Add(chaiLatte);
        }

        if (!hasTeaBags)
        {
            Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
            hasTeaBags = true;
        }

        orderCoffee.coffeeOrders.Add("ChaiLatte");
            
    }

    public void UnlockHotChocolate()
    {
        craftCoffee.recipes.Add("MilkCocoPowderNull");
        craftCoffee.recipes.Add("MilkNullCocoPowder");
        craftCoffee.recipes.Add("CocoPowderMilkNull");
        craftCoffee.recipes.Add("CocoPowderNullMilk");
        craftCoffee.recipes.Add("NullMilkCocoPowder");
        craftCoffee.recipes.Add("NullCocoPowderMilk");

        for (int i = amount; i == amount; i++)
        {
            craftCoffee.recipeResults.Add(hotChocolate);
        }

        if (!hasCocoPowder)
        {
            Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
            hasCocoPowder = true;
        }

        orderCoffee.coffeeOrders.Add("HotChocolate");
    }

    public void UnlockIcedCoffee()
    {
        craftCoffee.recipes.Add("IceCoffeeBeansWater");
        craftCoffee.recipes.Add("IceWaterCoffeeBeans");
        craftCoffee.recipes.Add("CoffeeBeansIceWater");
        craftCoffee.recipes.Add("CoffeeBeansWaterIce");
        craftCoffee.recipes.Add("WaterIceCoffeeBeans");
        craftCoffee.recipes.Add("WaterCoffeeBeansIce");

        for (int i = amount; i == amount; i++)
        {
            craftCoffee.recipeResults.Add(icedCoffee);
        }

        if (!hasIce)
        {
            Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
            hasIce = true;
        }

        orderCoffee.coffeeOrders.Add("IcedCoffee");
    }

    public void UnlockIcedLatte()
    {
        craftCoffee.recipes.Add("MilkCoffeeBeansIce");
        craftCoffee.recipes.Add("MilkIceCoffeeBeans");
        craftCoffee.recipes.Add("CoffeeBeansMilkIce");
        craftCoffee.recipes.Add("CoffeeBeansIceMilk");
        craftCoffee.recipes.Add("IceMilkCoffeeBeans");
        craftCoffee.recipes.Add("IceCoffeeBeansMilk");

        for (int i = amount; i == amount; i++)
        {
            craftCoffee.recipeResults.Add(icedLatte);
        }

        if (!hasIce)
        {
            Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
            hasIce = true;
        }

        orderCoffee.coffeeOrders.Add("IcedLatte");
    }

    public void UnlockMocha()
    {
        craftCoffee.recipes.Add("MilkCoffeeBeansCocoPowder");
        craftCoffee.recipes.Add("MilkCocoPowderCoffeeBeans");
        craftCoffee.recipes.Add("CoffeeBeansMilkCocoPowder");
        craftCoffee.recipes.Add("CoffeeBeansCocoPowderMilk");
        craftCoffee.recipes.Add("CocoPowderMilkCoffeeBeans");
        craftCoffee.recipes.Add("CocoPowderCoffeeBeansMilk");

        for (int i = amount; i == amount; i++)
        {
            craftCoffee.recipeResults.Add(mocha);
        }

        if (!hasCocoPowder)
        {
            Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
            hasCocoPowder = true;
        }

        orderCoffee.coffeeOrders.Add("Mocha");
    }

    public void Tea()
    {
        craftCoffee.recipes.Add("MilkWaterTeaBags");
        craftCoffee.recipes.Add("MilkTeaBagsWater");
        craftCoffee.recipes.Add("WaterMilkTeaBags");
        craftCoffee.recipes.Add("WaterTeaBagsMilk");
        craftCoffee.recipes.Add("TeaBagsMilkWater");
        craftCoffee.recipes.Add("TeaBagsWaterMilk");

        for (int i = amount; i == amount; i++)
        {
            craftCoffee.recipeResults.Add(tea);
        }

        if (!hasTeaBags)
        {
            Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
            hasTeaBags = true;
        }

        orderCoffee.coffeeOrders.Add("Tea");
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
