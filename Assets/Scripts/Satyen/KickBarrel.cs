using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBarrel : MonoBehaviour
{
    private Rigidbody rb;
    private bool activatable;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        activatable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && activatable)
        {
            //This code essentially does what you want the final result to be (press button, roll barrel, etc.)
            rb.AddForce(new Vector3(1.0f, 0.0f, 0.0f));
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
