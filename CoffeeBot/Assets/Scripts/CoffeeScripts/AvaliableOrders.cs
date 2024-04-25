using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvaliableOrders : MonoBehaviour
{
    public List<string> coffeeOrders = new List<string>();

    public List<Sprite> orderIcons = new List<Sprite>();

    public List<GameObject> orderListText = new List<GameObject>();

    public List<int> orderCost = new List<int>();
}
