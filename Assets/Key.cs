using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Key : MonoBehaviour
{
    [SerializeField] private Image passwordPrompt_day;
    //[SerializeField] private Image passwordPrompt_night;
    [SerializeField] private Mode mode;
    public Canvas passwordCanvas;
    public InputField password;

    private void Start()
    {
        passwordPrompt_day.enabled = false;
        //passwordPrompt_night.enabled = false;
        passwordCanvas.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (mode.isDay() && other.CompareTag("Player"))
        {
            passwordPrompt_day.enabled = true;
            //passwordPrompt_night.enabled = false;
            passwordCanvas.enabled = false;
            password.enabled = false;
        }
        if (!mode.isDay() && other.CompareTag("Player"))
        {
            passwordPrompt_day.enabled = false;
            //passwordPrompt_night.enabled = true;
            passwordCanvas.enabled = true;
            password.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            passwordPrompt_day.enabled = false;
            //passwordPrompt_night.enabled = false;
            passwordCanvas.enabled = false;
            password.enabled = false;
        }
    }
    void Update()
    {
        if (!mode.isDay())
            passwordPrompt_day.enabled = false;
        else
        {
            //passwordPrompt_night.enabled = false;
            passwordCanvas.enabled = false;
            password.enabled = false;
        }
    }

    public void checkPasswordCondition()
    {
        string receivedString = password.text;
        if (receivedString.Equals("5TE"))
        {
            Debug.Log("NB");
        }
        else
        {
            Debug.Log("WRONG");
        }
    }
}

