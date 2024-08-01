using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public SceneInfo sceneInfo;

    public Button CoffeeButton;
    public Button GoldButton;
    public Button HooverButton;
    public Button CardboardButton;
    public Button InmateButton;

    public Sprite CoffeeLockedSprite;
    public Sprite GoldLockedSprite;
    public Sprite HooverLockedSprite;
    public Sprite CardboardLockedSprite;
    public Sprite InmateLockedSprite;


    public void Start()
    {
      if(sceneInfo.OrdersCompleted < 20)
      {
            CoffeeButton.enabled = false;
            CoffeeButton.GetComponent<Image>().sprite = CoffeeLockedSprite;
      }

      if(sceneInfo.SpillsCleaned < 30)
      {
            HooverButton.enabled = false;
            HooverButton.GetComponent<Image>().sprite = HooverLockedSprite;
      }
      if (sceneInfo.GoodEndingAchieved == false)
      {
           GoldButton.enabled = false;
           GoldButton.GetComponent<Image>().sprite = GoldLockedSprite;
      }

      if (sceneInfo.BadEndingAchieved == false)
      {
          CardboardButton.enabled = false;
          CardboardButton.GetComponent<Image>().sprite = CardboardLockedSprite;
      }

      if (sceneInfo.PrisonEndingAchieved == false)
      {
          InmateButton.enabled = false;
          InmateButton.GetComponent<Image>().sprite = InmateLockedSprite;
      }


    }
}
