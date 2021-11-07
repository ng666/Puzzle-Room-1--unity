using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    [SerializeField] private Text sleep;
    public Mode mode;
    private bool isCollide;

    private void Start()
    {
        sleep.enabled = false;
        isCollide = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (!mode.isDay() && other.CompareTag("Player"))
        {
            sleep.enabled = true;
            isCollide = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sleep.enabled = false;
            isCollide = false;
        }
    }
    void Update()
    {
        if (mode.isDay())
        {
            sleep.enabled = false;
            isCollide = false;
        }

        if (isCollide)
        {
            if (Input.GetKeyDown(KeyCode.F))
                mode.toDayTime();
        }
    }

}
