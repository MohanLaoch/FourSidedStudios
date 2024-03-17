using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayTimer : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public SceneInfo sceneInfo;

    [Header("UI Elements")]
    public TextMeshProUGUI timerText;

    public GameObject upgradesMenu;
    public GameObject endOfDayMenu;

    [Header("Settings")]
    public float maxTime = 180;
    public float currentTime;
    private bool countDown = true;

    private bool hasLimit = true;
    public float timerLimit;

    private bool timerActive = true;

    public int day = 1;

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
        currentTime = maxTime;

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

        float minutes = Mathf.FloorToInt (currentTime / 60);
        float seconds = Mathf.FloorToInt (currentTime % 60);
        timerText.text = "Day: " + sceneInfo.dayCount.ToString("0") + " | Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    private void FinishDay()
    {
        timerActive = false;
        //pauseMenu.ActivateUpgradesMenu();
        pauseMenu.ActivateEndOfDayMenu();
        

    }


}
