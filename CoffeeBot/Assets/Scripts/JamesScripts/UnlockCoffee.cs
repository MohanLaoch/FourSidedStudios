using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCoffee : MonoBehaviour
{
    // Player starts off being able to make an Americano, a Latte, and a Cappuccino

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


}

/*
 * When unlocking a new coffee a button will be pressed to call the function
 * the function needs to do the following:
 * - add any needed ingredients storage
 * - allow the storage system to accept the new ingredients as "storedItems"
 * - add the new recipies to the "recipies" string
 * - add the new gameobject to "recipieResults"
 * - add the option for the NPCs to order the coffee
 */
