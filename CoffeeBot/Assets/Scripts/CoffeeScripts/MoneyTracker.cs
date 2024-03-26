using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public float money;
    public float moneyGiven = 5;
    public float tipDivide = 4;

    [Header("UIComponent")]
    //public TextMeshProUGUI timerText;
    public TextMeshProUGUI moneyText;
    public Slider slider;
    public Gradient sliderGradient;
    public Image sliderFill;

    [Header("Timer Settings")]
    public float maxTime = 30;
    public float currentTime;
    private bool countDown = true;

    public float timerLimit;

    private bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        //money = sceneInfo.money;

        // set the timer to maxTime, and the value of the slider to currentTime

        currentTime = maxTime;
        slider.maxValue = maxTime;
        slider.value = currentTime;

        // colour of the slider

        sliderFill.color = sliderGradient.Evaluate(1f);
        sliderFill.color = sliderGradient.Evaluate(slider.normalizedValue);

        // set the money text

        moneyText.text = ": " + sceneInfo.money.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
       // money = sceneInfo.money;

        // if the timer is active, countdown

        if (timerActive)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }

       // if the timer has limit and is above or below that limit set the timer text

        /*if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        { 
            currentTime = timerLimit;
            SetTimerText();
            enabled = false;
        }*/
      
        SetTimerText();
        //moneyText.text = ": " + money.ToString("0");
    }

    private void SetTimerText()
    {
        // update the timer text

        //timerText.text = currentTime.ToString("0");
        slider.value = currentTime;
        sliderFill.color = sliderGradient.Evaluate(slider.normalizedValue);
    }

    public void StartTimer()
    {
        // set the timer to maxTime, and the value of the slider to currentTime

        timerActive = true;
        currentTime = maxTime;
        slider.maxValue = maxTime;
        slider.value = currentTime;

        // set the colour of the timer

        sliderFill.color = sliderGradient.Evaluate(1f);
        sliderFill.color = sliderGradient.Evaluate(slider.normalizedValue);
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void CompleteOrder()
    {
        // stop the timer & give the player money and a tip & set the new money text & start the timer again

        StopTimer();
        sceneInfo.money += moneyGiven + (currentTime / tipDivide);
        moneyText.text = ": " + sceneInfo.money.ToString("0");
        //sceneInfo.money = money;
        StartTimer();
    }
}
