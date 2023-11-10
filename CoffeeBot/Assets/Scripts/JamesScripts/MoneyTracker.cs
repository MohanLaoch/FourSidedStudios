using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    public float money = 0;

    [Header("UIComponent")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI moneyText;
    public Slider slider;
    public Gradient sliderGradient;
    public Image sliderFill;

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
        slider.maxValue = maxTime;
        slider.value = currentTime;

        sliderFill.color = sliderGradient.Evaluate(1f);
        sliderFill.color = sliderGradient.Evaluate(slider.normalizedValue);

        moneyText.text = "Money: " + money.ToString("0");
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
        slider.value = currentTime;
        sliderFill.color = sliderGradient.Evaluate(slider.normalizedValue);
    }

    public void StartTimer()
    {
        timerActive = true;
        currentTime = maxTime;
        slider.maxValue = maxTime;
        slider.value = currentTime;

        sliderFill.color = sliderGradient.Evaluate(1f);
        sliderFill.color = sliderGradient.Evaluate(slider.normalizedValue);
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void CompleteOrder()
    {
        StopTimer();
        money += currentTime;
        moneyText.text = "Money: " + money.ToString("0");
        StartTimer();
    }
}
