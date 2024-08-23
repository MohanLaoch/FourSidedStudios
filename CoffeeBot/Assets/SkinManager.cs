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

    public Sprite CoffeeUnlockedSprite;
    public Sprite GoldUnlockedSprite;
    public Sprite HooverUnlockedSprite;
    public Sprite CardboardUnlockedSprite;
    public Sprite InmateUnlockedSprite;

    public void Start()
    {
      if(sceneInfo.OrdersCompleted < 10)
      {
            CoffeeButton.interactable = false;
            CoffeeButton.GetComponent<Image>().sprite = CoffeeLockedSprite;
      }
      else if(sceneInfo.OrdersCompleted >= 10)
      {
            CoffeeButton.interactable = true;
            CoffeeButton.GetComponent<Image>().sprite = CoffeeUnlockedSprite;
      }

      if (sceneInfo.SpillsCleaned < 5)
      {
            HooverButton.interactable = false;
            HooverButton.GetComponent<Image>().sprite = HooverLockedSprite;
      }
      else if (sceneInfo.SpillsCleaned >= 5)
      {
            HooverButton.interactable = true;
            HooverButton.GetComponent<Image>().sprite = HooverUnlockedSprite;
      }

      if (sceneInfo.GoodEndingAchieved == false)
      {
           GoldButton.interactable = false;
           GoldButton.GetComponent<Image>().sprite = GoldLockedSprite;
      }
      else if (sceneInfo.GoodEndingAchieved)
      {
            GoldButton.interactable = true;
            GoldButton.GetComponent<Image>().sprite = GoldUnlockedSprite;
      }

      if (sceneInfo.BadEndingAchieved == false)
      {
          CardboardButton.interactable = false;
          CardboardButton.GetComponent<Image>().sprite = CardboardLockedSprite;
      }
      else if(sceneInfo.BadEndingAchieved)
      {
          CardboardButton.interactable = true;
          CardboardButton.GetComponent<Image>().sprite = CardboardUnlockedSprite;
      }

      if (sceneInfo.PrisonEndingAchieved == false)
      {
          InmateButton.interactable = false;
          InmateButton.GetComponent<Image>().sprite = InmateLockedSprite;
      }
      else if(sceneInfo.PrisonEndingAchieved)
      {
          InmateButton.interactable = true;
          InmateButton.GetComponent<Image>().sprite = InmateUnlockedSprite;
      }
    }

    public void SkinCheck()
    {
        if (sceneInfo.OrdersCompleted < 10)
        {
            CoffeeButton.interactable = false;
            CoffeeButton.GetComponent<Image>().sprite = CoffeeLockedSprite;
        }
        else if (sceneInfo.OrdersCompleted >= 10)
        {
            CoffeeButton.interactable = true;
            CoffeeButton.GetComponent<Image>().sprite = CoffeeUnlockedSprite;
        }

        if (sceneInfo.SpillsCleaned < 5)
        {
            HooverButton.interactable = false;
            HooverButton.GetComponent<Image>().sprite = HooverLockedSprite;
        }
        else if (sceneInfo.SpillsCleaned >= 5)
        {
            HooverButton.interactable = true;
            HooverButton.GetComponent<Image>().sprite = HooverUnlockedSprite;
        }

        if (sceneInfo.GoodEndingAchieved == false)
        {
            GoldButton.interactable = false;
            GoldButton.GetComponent<Image>().sprite = GoldLockedSprite;
        }
        else if (sceneInfo.GoodEndingAchieved)
        {
            GoldButton.interactable = true;
            GoldButton.GetComponent<Image>().sprite = GoldUnlockedSprite;
        }

        if (sceneInfo.BadEndingAchieved == false)
        {
            CardboardButton.interactable = false;
            CardboardButton.GetComponent<Image>().sprite = CardboardLockedSprite;
        }
        else if (sceneInfo.BadEndingAchieved)
        {
            CardboardButton.interactable = true;
            CardboardButton.GetComponent<Image>().sprite = CardboardUnlockedSprite;
        }

        if (sceneInfo.PrisonEndingAchieved == false)
        {
            InmateButton.interactable = false;
            InmateButton.GetComponent<Image>().sprite = InmateLockedSprite;
        }
        else if (sceneInfo.PrisonEndingAchieved)
        {
            InmateButton.interactable = true;
            InmateButton.GetComponent<Image>().sprite = InmateUnlockedSprite;
        }
    }
}
