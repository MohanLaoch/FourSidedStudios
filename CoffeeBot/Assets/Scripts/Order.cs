using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<string> coffeeOrder = new List<string>();

    private void Start()
    {
        CreateOrder();
    }

    public void CreateOrder()
    {
        int randomIndex = Random.Range(0, coffeeOrder.Count);

        string currentOrder = coffeeOrder[randomIndex];

        Debug.Log(currentOrder);
    }
}

 /*
 * so I need to create a system that allows the player to deliver an order to a customer or spot
 * the order will come in which will be randomly chosen from a list
 * 
 * this is so an npc could generate it (we can worry about when exactly it's called later)
 * 
 * what should the list beeeeee???? a string??? ok lets do a string
 * yeah actually string makes sense because I can connect that to tags potentially
 * 
 * likely it will be done through a function that can be called
 * it'll be called once the game is started
 * 
 * (I will also need to make a coffee crafting system but that can be done at some other point)
 */
