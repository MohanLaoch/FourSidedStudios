using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;

public class MoneyTracker : MonoBehaviour
{
    public Player player;
    public ParticleSystem moneyEffect;
    private EventInstance moneySound;
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
    public TextMeshProUGUI givenMoneyText;

    public Animator givenMoneyAnim;
    public AnimationEvent givenMoneyAnimEvent;

    public float MoneyGivenCooldown = 3;
    public bool MoneyIsGiven;
    [Header("Timer Settings")]
    public float maxTime = 90;
    public float currentTime;
    private bool countDown = true;

    public float timerLimit;

    private bool timerActive = true;

    

    [HideInInspector]
    public bool upset = false;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        moneySound = AudioManager.instance.CreateInstance(FMODEvents.instance.NPCMoney);


        moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        givenMoneyText = GameObject.Find("GivenMoneyText").GetComponent<TextMeshProUGUI>();

        givenMoneyAnim = GameObject.Find("GivenMoneyText").GetComponent<Animator>();
        
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

        if (currentTime <= 0)
        {
            upset = true;
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

        if(MoneyIsGiven)
        {
            MoneyGivenCooldown -= Time.deltaTime;

            if(MoneyGivenCooldown <= 0)
            {
                givenMoneyAnim.SetBool("MoneyGiven", false);
                MoneyIsGiven = false;
            }
        }

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
        if (sceneInfo.dayCount != 0)
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
        else
        {
            timerActive = false;
        }
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void CompleteOrder()
    {

        player.Holding = false;
        // stop the timer & give the player money and a tip & set the new money text & start the timer again

        StopTimer();
        
        
        if (!upset)
        {
            sceneInfo.money += moneyGiven + (maxTime / tipDivide);
            givenMoneyText.text = "+" + (moneyGiven + (maxTime / tipDivide)).ToString("0");

        }
        else
        {
            sceneInfo.money += moneyGiven;
            givenMoneyText.text = "+" + moneyGiven.ToString("0");

        }

        givenMoneyAnim.SetBool("MoneyGiven", true);
        MoneyIsGiven = true;
        sceneInfo.OrdersCompleted++;



        moneyText.text = ": " + sceneInfo.money.ToString("0");
        //trigger money effect here
        moneyEffect.Play();

        //trigger money sound effect here
        UpdateMoneySound();
        //sceneInfo.money = money;
        StartTimer();
    }

    public void UpdateMoneySound()
    {
        PLAYBACK_STATE playbackState;
        moneySound.getPlaybackState(out playbackState);
       
        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            moneySound.start();
        }
    }
}
