using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementPopUpManager : MonoBehaviour
{
    public SceneInfo sceneInfo;
    //public TextMeshProUGUI achievementText;
    public Sprite achievementSprite1;
    public Sprite achievementSprite2;
    public Sprite achievementSprite3;
    public Sprite achievementSprite4;
    public Sprite achievementSprite5;

    private void Start()
    {
        if (sceneInfo.SpillsCleaned >= 5)
        {
            sceneInfo.hasRun1 = true;
        }
        if (sceneInfo.OrdersCompleted >= 10)
        {
            sceneInfo.hasRun2 = true;
        }
        if (sceneInfo.GoodEndingAchieved)
        {
            sceneInfo.hasRun3 = true;
        }
        if (sceneInfo.BadEndingAchieved)
        {
            sceneInfo.hasRun4 = true;
        }
        if (sceneInfo.PrisonEndingAchieved)
        {
            sceneInfo.hasRun5 = true;
        }
    }

    private void Update()
    {
        if(sceneInfo.SpillsCleaned >= 5 && sceneInfo.hasRun1 == false)
        {
            sceneInfo.hasRun1 = true;
            PlayAnim1();
        }

        if(sceneInfo.OrdersCompleted >= 10 && sceneInfo.hasRun2 == false)
        {
            sceneInfo.hasRun2 = true;
            PlayAnim2();
        }

        if(sceneInfo.GoodEndingAchieved && sceneInfo.hasRun3 == false)
        {
            sceneInfo.hasRun3 = true;
            PlayAnim3();
        }

        if (sceneInfo.BadEndingAchieved && sceneInfo.hasRun4 == false)
        {
            sceneInfo.hasRun4 = true;
            PlayAnim4();
        }

        if (sceneInfo.PrisonEndingAchieved && sceneInfo.hasRun5 == false)
        {
            sceneInfo.hasRun5 = true;
            PlayAnim5();
        }
    }

    public void PlayAnim1()
    {
            GetComponent<Image>().sprite = achievementSprite1;
            GetComponent<Animator>().SetTrigger("AchievementUnlocked");
            //achievementText.text = "Hoover skin unlocked! Clean 30 spills." + sceneInfo.SpillsCleaned.ToString() + "/ 30";
            
    }

    public void PlayAnim2()
    {
            GetComponent<Image>().sprite = achievementSprite2;
            GetComponent<Animator>().SetTrigger("AchievementUnlocked");
            //achievementText.text = "Coffee skin unlocked! Complete 20 orders." + sceneInfo.OrdersCompleted.ToString() + "/ 20";
        
    }
    public void PlayAnim3()
    {
            GetComponent<Image>().sprite = achievementSprite3;
            GetComponent<Animator>().SetTrigger("AchievementUnlocked");
            //achievementText.text = "Gold skin unlocked! Earned over 50 credits.";
        
    }
    public void PlayAnim4()
    {
            GetComponent<Image>().sprite = achievementSprite4;
            GetComponent<Animator>().SetTrigger("AchievementUnlocked");
            //achievementText.text = "Cardboard skin unlocked! Earned under 50 credits.";
        
    }
    public void PlayAnim5()
    {
            GetComponent<Image>().sprite = achievementSprite5;
            GetComponent<Animator>().SetTrigger("AchievementUnlocked");
            //achievementText.text = "Inmate skin unlocked! Injured 10 customers.";
        
    }
}
