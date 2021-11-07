using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBehavior : MonoBehaviour
{

    public GameObject activateTextMessage;
    [SerializeField]
    private Vector3 teleportDestination;

    // Start is called before the first frame update
    void Start()
    {
        activateTextMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Activate"))
        {
            activateTextMessage.SetActive(true);
        }
        if (other.gameObject.CompareTag("Radiation"))
        {
            gameObject.GetComponent<TestPlayerController>().enabled = false; // Teleports player back to teleportDestination
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = teleportDestination;
            gameObject.GetComponent<TestPlayerController>().enabled = true;
            gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Activate"))
        {
            activateTextMessage.SetActive(false);
        }
    }

}
