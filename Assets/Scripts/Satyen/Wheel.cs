using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private Rigidbody rb;
    private bool activatable;

    public GameObject Player;
    private LightController _lightController;

    public int sequenceNumber; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        activatable = false;
        _lightController = Player.GetComponent<LightController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && activatable)
        {
            //This code essentially does what you want the final result to be (press button, roll barrel, etc.)
            if (_lightController.turnedWheels[_lightController.turnedWheels.Count -1] != sequenceNumber)
            {
                _lightController.turnedWheels.Add(sequenceNumber);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activatable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activatable = false;
        }
    }
}
