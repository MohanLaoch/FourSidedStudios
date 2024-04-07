using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockCoffee : MonoBehaviour
{
    public SceneInfo sceneInfo;
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

    [Header("MoneyText")]
    public TextMeshProUGUI MoneyText;


    public void Start()
    {
      if(sceneInfo.ChaiLatteUnlocked)
        {
            UnlockChaiLatte();
        }
      if(sceneInfo.HotChocolateUnlocked)
        {
            UnlockHotChocolate();
        }
      if(sceneInfo.IcedCoffeeUnlocked)
        {
            UnlockIcedCoffee();
        }
      if(sceneInfo.IcedLatteUnlocked)
        {
            UnlockIcedLatte();
        }
      if(sceneInfo.MochaUnlocked)
        {
            UnlockMocha();
        }
      if(sceneInfo.TeaUnlocked)
        {
            UnlockTea();
        }


    }
    public void UnlockChaiLatte()
    {
        if(sceneInfo.money >= 15)
        {
            sceneInfo.money -= 15;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");

            craftCoffee.recipes.Add("MilkTeaBagsNull");
            craftCoffee.recipes.Add("MilkNullTeaBags");
            craftCoffee.recipes.Add("TeaBagsMilkNull");
            craftCoffee.recipes.Add("TeaBagsNullMilk");
            craftCoffee.recipes.Add("NullMilkTeaBags");
            craftCoffee.recipes.Add("NullTeaBagsMilk");

            for (int i = 0; i < 6; i++)
            {
                craftCoffee.recipeResults.Add(chaiLatte);

                craftCoffee.recipeImages.Add(chaiLatteSprite);

                craftCoffee.recipeNames.Add("Chai Latte");
            }

            if (!hasTeaBags)
            {
                Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
                hasTeaBags = true;
            }

            avaliableOrders.coffeeOrders.Add("Chai Latte");
            avaliableOrders.orderIcons.Add(chaiLatteSprite);

            sceneInfo.ChaiLatteUnlocked = true;
        }
       
    }

    public void UnlockHotChocolate()
    {
        if(sceneInfo.money >= 15)
        {
            sceneInfo.money -= 15;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");

            craftCoffee.recipes.Add("MilkCocoPowderNull");
            craftCoffee.recipes.Add("MilkNullCocoPowder");
            craftCoffee.recipes.Add("CocoPowderMilkNull");
            craftCoffee.recipes.Add("CocoPowderNullMilk");
            craftCoffee.recipes.Add("NullMilkCocoPowder");
            craftCoffee.recipes.Add("NullCocoPowderMilk");

            for (int i = 0; i < 6; i++)
            {
                craftCoffee.recipeResults.Add(hotChocolate);

                craftCoffee.recipeImages.Add(hotChocolateSprite);

                craftCoffee.recipeNames.Add("Hot Chocolate");
            }

            if (!hasCocoPowder)
            {
                Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
                hasCocoPowder = true;
            }

            avaliableOrders.coffeeOrders.Add("Hot Chocolate");
            avaliableOrders.orderIcons.Add(hotChocolateSprite);

            sceneInfo.HotChocolateUnlocked = true;
        }
        
    }

    public void UnlockIcedCoffee()
    {
        if(sceneInfo.money >= 15)
        {
            sceneInfo.money -= 15;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");

            craftCoffee.recipes.Add("IceCoffeeBeansWater");
            craftCoffee.recipes.Add("IceWaterCoffeeBeans");
            craftCoffee.recipes.Add("CoffeeBeansIceWater");
            craftCoffee.recipes.Add("CoffeeBeansWaterIce");
            craftCoffee.recipes.Add("WaterIceCoffeeBeans");
            craftCoffee.recipes.Add("WaterCoffeeBeansIce");

            for (int i = 0; i < 6; i++)
            {
                craftCoffee.recipeResults.Add(icedCoffee);

                craftCoffee.recipeImages.Add(icedCoffeeSprite);

                craftCoffee.recipeNames.Add("Iced Coffee");
            }

            if (!hasIce)
            {
                Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
                hasIce = true;
            }

            avaliableOrders.coffeeOrders.Add("Iced Coffee");
            avaliableOrders.orderIcons.Add(icedCoffeeSprite);

            sceneInfo.IcedCoffeeUnlocked = true;
        }
       
    }

    public void UnlockIcedLatte()
    {
        if (sceneInfo.money >= 15)
        {
            sceneInfo.money -= 15;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");

            craftCoffee.recipes.Add("MilkCoffeeBeansIce");
            craftCoffee.recipes.Add("MilkIceCoffeeBeans");
            craftCoffee.recipes.Add("CoffeeBeansMilkIce");
            craftCoffee.recipes.Add("CoffeeBeansIceMilk");
            craftCoffee.recipes.Add("IceMilkCoffeeBeans");
            craftCoffee.recipes.Add("IceCoffeeBeansMilk");

            for (int i = 0; i < 6; i++)
            {
                craftCoffee.recipeResults.Add(icedLatte);

                craftCoffee.recipeImages.Add(icedLatteSprite);

                craftCoffee.recipeNames.Add("Iced Latte");
            }

            if (!hasIce)
            {
                Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
                hasIce = true;
            }

            avaliableOrders.coffeeOrders.Add("Iced Latte");
            avaliableOrders.orderIcons.Add(icedLatteSprite);

            sceneInfo.IcedLatteUnlocked = true;
        }
    }

    public void UnlockMocha()
    {
        if (sceneInfo.money >= 15)
        {
            sceneInfo.money -= 15;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");

            craftCoffee.recipes.Add("MilkCoffeeBeansCocoPowder");
            craftCoffee.recipes.Add("MilkCocoPowderCoffeeBeans");
            craftCoffee.recipes.Add("CoffeeBeansMilkCocoPowder");
            craftCoffee.recipes.Add("CoffeeBeansCocoPowderMilk");
            craftCoffee.recipes.Add("CocoPowderMilkCoffeeBeans");
            craftCoffee.recipes.Add("CocoPowderCoffeeBeansMilk");

            for (int i = 0; i < 6; i++)
            {
                craftCoffee.recipeResults.Add(mocha);

                craftCoffee.recipeImages.Add(mochaSprite);

                craftCoffee.recipeNames.Add("Mocha");
            }

            if (!hasCocoPowder)
            {
                Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
                hasCocoPowder = true;
            }

            avaliableOrders.coffeeOrders.Add("Mocha");
            avaliableOrders.orderIcons.Add(mochaSprite);

            sceneInfo.MochaUnlocked = true;
        }
    }

    public void UnlockTea()
    {
        if (sceneInfo.money >= 15)
        {
            sceneInfo.money -= 15;
            MoneyText.text = ": " + sceneInfo.money.ToString("0");

            craftCoffee.recipes.Add("MilkWaterTeaBags");
            craftCoffee.recipes.Add("MilkTeaBagsWater");
            craftCoffee.recipes.Add("WaterMilkTeaBags");
            craftCoffee.recipes.Add("WaterTeaBagsMilk");
            craftCoffee.recipes.Add("TeaBagsMilkWater");
            craftCoffee.recipes.Add("TeaBagsWaterMilk");

            for (int i = 0; i < 6; i++)
            {
                craftCoffee.recipeResults.Add(tea);

                craftCoffee.recipeImages.Add(teaSprite);

                craftCoffee.recipeNames.Add("Tea");
            }

            if (!hasTeaBags)
            {
                Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
                hasTeaBags = true;
            }

            avaliableOrders.coffeeOrders.Add("Tea");
            avaliableOrders.orderIcons.Add(teaSprite);

            sceneInfo.TeaUnlocked = true;
        }
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
