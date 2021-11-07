using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public static bool allowInputs;

    public Slider countdownBar;
    private bool countDown = true;

    public float countDownTime = 90;
    public float refillTime = 90;

    private void Start()
    {
        //Set the max value to the refill time
        countdownBar.maxValue = refillTime;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (countdownBar.maxValue != refillTime)
            countdownBar.maxValue = refillTime;

        if (countDown) //Scale the countdown time to go faster than the refill time
            countdownBar.value -= Time.deltaTime / countDownTime * refillTime;
        else
            countdownBar.value += Time.deltaTime;

        //If we are at 0, start to refill
        if (countdownBar.value <= 0)
        {
            countDown = false;
            allowInputs = false;
        }
        else if (countdownBar.value >= refillTime)
        {
            countDown = true;
            allowInputs = true;
        }
    }

    public void setHealth(float h)
    {
        if (h > countdownBar.maxValue)
        {
            h = countdownBar.maxValue;
        }
        countdownBar.value = h;
    }
    public void changeHealth(float h)
    {
        if (h > countdownBar.maxValue)
        {
            h = countdownBar.maxValue;
        }
        if (h < 0)
        {
            h = 0;
        }
        countdownBar.value += h;
    }
    public float getHealth()
    {
        return countdownBar.value;
    }

}