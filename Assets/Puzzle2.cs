using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField] private Image puzzle2;
    [SerializeField] private Mode mode;

    private void Start()
    {
        puzzle2.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (mode.isDay() && other.CompareTag("Player"))
        {
            puzzle2.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzle2.enabled = false;
        }
    }

    void Update()
    {
        if (!mode.isDay())
            puzzle2.enabled = false;
    }
}
