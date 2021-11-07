using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3 : MonoBehaviour
{
    [SerializeField] private Image puzzle3;
    [SerializeField] private Mode mode;

    private void Start()
    {
        puzzle3.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (mode.isDay() && other.CompareTag("Player"))
        {
            puzzle3.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzle3.enabled = false;
        }
    }

    void Update()
    {
        if (!mode.isDay())
            puzzle3.enabled = false;
    }
}
