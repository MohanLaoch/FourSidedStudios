using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    public float money = 0;

    [Header("UIComponent")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI moneyText;

    [Header("Timer Settings")]
    public float maxTime = 30;
    public float currentTime;
    private bool countDown = true;

    private bool hasLimit = true;
    public float timerLimit;

    private bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        { 
            currentTime = timerLimit;
            SetTimerText();
            enabled = false;
        }
        
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }

    public void StartTimer()
    {
        timerActive = true;
        currentTime = maxTime;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void CompleteOrder()
    {
        StopTimer();
        money += currentTime;
        moneyText.text = money.ToString("0");
        StartTimer();
    }
}
