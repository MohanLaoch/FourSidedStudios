using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayTimer : MonoBehaviour, IDataPersistence
{
    public PauseMenu pauseMenu;
    public SceneInfo sceneInfo;

    [Header("UI Elements")]
    public TextMeshProUGUI dayCounterText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI creditsText;
    public TextMeshProUGUI billsText;
    public TextMeshProUGUI billsText2;
    public TextMeshProUGUI totalEarnedText;
    public TextMeshProUGUI MoneyText;



    public GameObject upgradesMenu;
    public GameObject endOfDayMenu;

    public GameObject[] UiElements;


    [Header("Settings")]
    public float maxTime = 180;
    public float currentTime;
    private bool countDown = true;

    private bool hasLimit = true;
    public float timerLimit;

    private bool timerActive = true;

    public int day = 1;

    public void LoadData(GameData data)
    {
        currentTime = data.playerAttributesData.currentTime;
    }

    public void SaveData(GameData data)
    {
        data.playerAttributesData.currentTime = currentTime;
    }

    private void Awake()
    {
        
    }


    private void Start()
    {
        StartFirstDay();       

    }

    private void Update()
    {


        // if the timer is active, countdown

        if (timerActive)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }

        // if the timer has limit and is above or below that limit set the timer text

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            enabled = false;
        }
        

        if (currentTime <= 0)
        {
            FinishDay();
        }

        SetTimerText();

    }

    private void StartFirstDay()
    {
        endOfDayMenu.SetActive(false);
        timerActive = true;

        if (!DataPersistenceManager.instance.HasGameData())
        {
            currentTime = maxTime;
        }
        else
        {
            DataPersistenceManager.instance.LoadGame();
        }

    }

   /* public void StartNewDay()
    {
        if (day >= 5)
        {
            pauseMenu.ResetScene();
        }

        upgradesMenu.SetActive(false);
        day += 1;
        sceneInfo.dayCount = day;
        timerActive = true;
        currentTime = maxTime;
    }*/

    private void SetTimerText()
    {
        if (currentTime <= 30)
        {
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            dayCounterText.text = "Day: " + sceneInfo.dayCount.ToString("0") + "/5" + " | Time left: ";
            timerText.color = Color.red;
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            dayCounterText.text = "Day: " + sceneInfo.dayCount.ToString("0") + "/5" + " | Time left: ";
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }

    private void FinishDay()
    {
        timerActive = false;
        pauseMenu.ActivateEndOfDayMenu();
        creditsText.text = "Credits earned: " + sceneInfo.money.ToString("0");
        sceneInfo.money -= sceneInfo.WaterBills;
        sceneInfo.money -= sceneInfo.ElectricityBills;

        billsText.text = "Water bills: " + sceneInfo.WaterBills.ToString("0");
        billsText2.text = "Electricity bills: " + sceneInfo.ElectricityBills.ToString("0");
        totalEarnedText.text = "Total credits: " + sceneInfo.money.ToString("0");
        MoneyText.text = sceneInfo.money.ToString("0");


        DisableUI();
        



    }
    public void EnableUI()
    {
        for (int i = 0; i < UiElements.Length; i++)
        {
            UiElements[i].SetActive(true);
        }

    }

    public void DisableUI()
    {
        for (int i = 0; i < UiElements.Length; i++)
        {
            UiElements[i].SetActive(false);
        }

    }


}
