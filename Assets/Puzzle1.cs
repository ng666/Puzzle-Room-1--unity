using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour
{
    [SerializeField] private Image puzzle1;
    [SerializeField] private Mode mode;

    private void Start()
    {
        puzzle1.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(mode.isDay() && other.CompareTag("Player"))
        {
            puzzle1.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzle1.enabled = false;
        }
    }

    void Update()
    {
        if(!mode.isDay())
            puzzle1.enabled = false;
    }
}
