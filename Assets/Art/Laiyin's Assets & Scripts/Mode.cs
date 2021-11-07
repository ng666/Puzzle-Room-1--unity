using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode: MonoBehaviour
{
    [SerializeField] private bool isDayTime;
    [SerializeField] private float currentTime;
    public FadeController fading;
    public float DayTime;
    public float NightTime;
    public GameObject A_Day;
    public GameObject A_Night;
    public GameObject M_Day;
    public GameObject M_Night;
    public GameObject clock_3pm;
    public GameObject clock_9pm;
    public GameObject light;

    void Start()
    {
        currentTime = 0;
        isDayTime = true;
        A_Day.SetActive(true);
        A_Night.SetActive(false);
        M_Day.SetActive(true);
        M_Night.SetActive(false);
        clock_3pm.SetActive(true);
        clock_9pm.SetActive(false);
        light.SetActive(true);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(isDayTime && currentTime >= DayTime)
        {
            StartCoroutine(waitForFade());
        }
        else if(!isDayTime && currentTime >= NightTime)
        {
            StartCoroutine(waitForFade());
        }
    }

    IEnumerator waitForFade()
    {
        fading.fade();
        isDayTime = !isDayTime;
        currentTime = 0;

        yield return new WaitForSeconds(1.5f);
        if (isDayTime)
        {
            A_Day.SetActive(true);
            A_Night.SetActive(false);
            M_Day.SetActive(true);
            M_Night.SetActive(false);
            clock_3pm.SetActive(true);
            clock_9pm.SetActive(false);
            light.SetActive(true);
        }
        else
        {
            A_Day.SetActive(false);
            A_Night.SetActive(true);
            M_Day.SetActive(false);
            M_Night.SetActive(true);
            clock_3pm.SetActive(false);
            clock_9pm.SetActive(true);
            light.SetActive(false);
        }
    }

    public bool isDay()
    {
        return isDayTime;
    }

    public void toDayTime()
    {
        StartCoroutine(waitForFade());
    }
}
