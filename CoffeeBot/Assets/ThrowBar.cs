using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;

    public Image fill;

   
    public void SetMaxThrow(float throwforce)
    {
        slider.maxValue = throwforce;
        slider.value = throwforce;

        fill.color = gradient.Evaluate(1f);
    }

    
    public void SetThrow(float throwforce)
    {
        slider.value = throwforce;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
