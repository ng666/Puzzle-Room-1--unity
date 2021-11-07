using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    private Rigidbody rb;
    private bool activatable;

    public GameObject Player;
    private ColoredPlatformManager platformManager;

    public string color;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        activatable = false;
        platformManager = Player.GetComponent<ColoredPlatformManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && activatable)
        {
            if (color == "green")
            {
                Debug.Log("green activated");
                platformManager.greenUp = !platformManager.greenUp;
            }
            if (color == "red")
            {
                platformManager.redUp = !platformManager.redUp;
            }
            if (color == "blue")
            {
                platformManager.blueUp = !platformManager.blueUp;
            }
            if (color == "yellow")
            {
                platformManager.yellowUp = !platformManager.yellowUp;
            }
            if (color == "purple")
            {
                platformManager.purpleUp = !platformManager.purpleUp;
            }
            //This code essentially does what you want the final result to be (press button, roll barrel, etc.)

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
