using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockCoffee : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public Player player;
    public PauseMenu pauseMenu;
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

    [Header("Chai Prefabs")]
    public GameObject chaiLatte;
    public Sprite chaiLatteSprite;
    public GameObject chaiLatteOT;
    public GameObject[] chaiLatteRecipe;
    public int chaiAmount;

    [Header("Hot Chocolate Prefabs")]
    public GameObject hotChocolate;
    public Sprite hotChocolateSprite;
    public GameObject hotChocolateOT;
    public GameObject[] hotChocolateRecipe;
    public int hotChocolateAmount;

    [Header("Iced Coffee Prefabs")]
    public GameObject icedCoffee;
    public Sprite icedCoffeeSprite;
    public GameObject icedCoffeeOT;
    public GameObject[] icedCoffeeRecipe;
    public int icedCoffeeAmount;

    [Header("Iced Latte Prefabs")]
    public GameObject icedLatte;
    public Sprite icedLatteSprite;
    public GameObject icedLatteOT;
    public GameObject[] icedLatteRecipe;
    public int icedLatteAmount;

    [Header("Mocha Prefabs")]
    public GameObject mocha;
    public Sprite mochaSprite;
    public GameObject mochaOT;
    public GameObject[] mochaRecipe;
    public int mochaAmount;

    [Header("Tea Prefabs")]
    public GameObject tea;
    public Sprite teaSprite;
    public GameObject teaOT;
    public GameObject[] teaRecipe;
    public int teaAmount;

    [Header("MoneyText")]
    public TextMeshProUGUI MoneyText;


    public void Start()
    {
      if(sceneInfo.dayCount >= 4) // Tea day 4
      {
            UnlockChaiLatte();
      }
      if(sceneInfo.dayCount >= 3) // Choc day 3
      {
            UnlockHotChocolate();
      }
      if(sceneInfo.dayCount >= 2) // Ice day 2
      {
            UnlockIcedCoffee();
      }
      if(sceneInfo.dayCount >= 2) // Ice day 2
      {
            UnlockIcedLatte();
      }
      if(sceneInfo.dayCount >= 3) // Choc day 3
      {
            UnlockMocha();
      }
      if(sceneInfo.dayCount >= 4) // Tea day 4
      {
            UnlockTea();
      }
    }
    public void UnlockChaiLatte()
    {
        /*if(sceneInfo.ChaiLatteUnlocked)
        {
            return;
        }*/
        
        if(sceneInfo.money >= 15 || sceneInfo.ChaiLatteUnlocked)
        {
            if(!sceneInfo.ChaiLatteUnlocked)
            {
                sceneInfo.money -= 15;
            }
            
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

            foreach (GameObject i in chaiLatteRecipe)
            {
                i.SetActive(true);
            }

            if (!hasTeaBags)
            {
                Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
                hasTeaBags = true;
            }

            avaliableOrders.coffeeOrders.Add("Chai Latte");
            avaliableOrders.orderIcons.Add(chaiLatteSprite);

            avaliableOrders.orderListText.Add(chaiLatteOT);

            avaliableOrders.orderCost.Add(chaiAmount);

            sceneInfo.ChaiLatteUnlocked = true;

            pauseMenu.CoffeeUnlock1.interactable = false;

            //DataPersistenceManager.instance.SaveGame();
        }
        else if(!sceneInfo.ChaiLatteUnlocked)
        {
            StartCoroutine(player.NoCredits());
        }
       
    }

    public void UnlockHotChocolate()
    {
        /*if (sceneInfo.HotChocolateUnlocked)
        {
            return;
        }*/

        if (sceneInfo.money >= 15 || sceneInfo.HotChocolateUnlocked)
        {
            if (!sceneInfo.HotChocolateUnlocked)
            {
                sceneInfo.money -= 15;
            }
            
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

            foreach (GameObject i in hotChocolateRecipe)
            {
                i.SetActive(true);
            }

            if (!hasCocoPowder)
            {
                Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
                hasCocoPowder = true;
            }

            avaliableOrders.coffeeOrders.Add("Hot Chocolate");
            avaliableOrders.orderIcons.Add(hotChocolateSprite);

            avaliableOrders.orderListText.Add(hotChocolateOT);

            avaliableOrders.orderCost.Add(hotChocolateAmount);

            sceneInfo.HotChocolateUnlocked = true;

            pauseMenu.CoffeeUnlock2.interactable = false;

            //DataPersistenceManager.instance.SaveGame();
        }
        else if(!sceneInfo.HotChocolateUnlocked)
        {
            StartCoroutine(player.NoCredits());
        }

    }

    public void UnlockIcedCoffee()
    {
        /*if (sceneInfo.IcedCoffeeUnlocked)
        {
            return;
        }*/

        if (sceneInfo.money >= 15 || sceneInfo.IcedCoffeeUnlocked)
        {
            if (!sceneInfo.IcedCoffeeUnlocked)
            {
                sceneInfo.money -= 15;
            }

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

            foreach (GameObject i in icedCoffeeRecipe)
            {
                i.SetActive(true);
            }

            if (!hasIce)
            {
                Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
                hasIce = true;
            }

            avaliableOrders.coffeeOrders.Add("Iced Coffee");
            avaliableOrders.orderIcons.Add(icedCoffeeSprite);

            avaliableOrders.orderListText.Add(icedCoffeeOT);

            avaliableOrders.orderCost.Add(icedCoffeeAmount);

            sceneInfo.IcedCoffeeUnlocked = true;

            pauseMenu.CoffeeUnlock3.interactable = false;

           // DataPersistenceManager.instance.SaveGame();
        }
        else if(!sceneInfo.IcedCoffeeUnlocked)
        {
            StartCoroutine(player.NoCredits());
        }

    }

    public void UnlockIcedLatte()
    {
        /*if (sceneInfo.IcedLatteUnlocked)
        {
            return;
        }*/

        if (sceneInfo.money >= 15 || sceneInfo.IcedLatteUnlocked)
        {
            if (!sceneInfo.IcedLatteUnlocked)
            {
                sceneInfo.money -= 15;
            }
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

            foreach (GameObject i in icedLatteRecipe)
            {
                i.SetActive(true);
            }

            if (!hasIce)
            {
                Instantiate(ice, new Vector3(iceSpawn.position.x, iceSpawn.position.y, iceSpawn.position.z), Quaternion.identity);
                hasIce = true;
            }

            avaliableOrders.coffeeOrders.Add("Iced Latte");
            avaliableOrders.orderIcons.Add(icedLatteSprite);

            avaliableOrders.orderListText.Add(icedLatteOT);

            avaliableOrders.orderCost.Add(icedLatteAmount);

            sceneInfo.IcedLatteUnlocked = true;

            pauseMenu.CoffeeUnlock4.interactable = false;

            //DataPersistenceManager.instance.SaveGame();
        }
        else if(!sceneInfo.IcedLatteUnlocked)
        {
            StartCoroutine(player.NoCredits());
        }
    }

    public void UnlockMocha()
    {
        /*if (sceneInfo.MochaUnlocked)
        {
            return;
        }*/

        if (sceneInfo.money >= 15 || sceneInfo.MochaUnlocked)
        {
            if (!sceneInfo.MochaUnlocked)
            {
                sceneInfo.money -= 15;
            }

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

            foreach (GameObject i in mochaRecipe)
            {
                i.SetActive(true);
            }

            if (!hasCocoPowder)
            {
                Instantiate(cocoPowder, new Vector3(cocoPowderSpawn.position.x, cocoPowderSpawn.position.y, cocoPowderSpawn.position.z), Quaternion.identity);
                hasCocoPowder = true;
            }

            avaliableOrders.coffeeOrders.Add("Mocha");
            avaliableOrders.orderIcons.Add(mochaSprite);

            avaliableOrders.orderListText.Add(mochaOT);

            avaliableOrders.orderCost.Add(mochaAmount);

            sceneInfo.MochaUnlocked = true;

            pauseMenu.CoffeeUnlock5.interactable = false;

           // DataPersistenceManager.instance.SaveGame();
        }
        else if (!sceneInfo.MochaUnlocked)
        {
            StartCoroutine(player.NoCredits());
        }
    }

    public void UnlockTea()
    {
        /*if (sceneInfo.TeaUnlocked)
        {
            return;
        }*/

        if (sceneInfo.money >= 15 || sceneInfo.TeaUnlocked)
        {
            if (!sceneInfo.TeaUnlocked)
            {
                sceneInfo.money -= 15;
            }

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

            foreach (GameObject i in teaRecipe)
            {
                i.SetActive(true);
            }

            if (!hasTeaBags)
            {
                Instantiate(teaBags, new Vector3(teaBagsSpawn.position.x, teaBagsSpawn.position.y, teaBagsSpawn.position.z), Quaternion.identity);
                hasTeaBags = true;
            }

            avaliableOrders.coffeeOrders.Add("Tea");
            avaliableOrders.orderIcons.Add(teaSprite);

            avaliableOrders.orderListText.Add(teaOT);

            avaliableOrders.orderCost.Add(teaAmount);

            sceneInfo.TeaUnlocked = true;

            pauseMenu.CoffeeUnlock6.interactable = false;

            //DataPersistenceManager.instance.SaveGame();
        }
        else if (!sceneInfo.TeaUnlocked)
        {
            StartCoroutine(player.NoCredits());
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
