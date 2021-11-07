using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 teleportDestination;

    void KillMe()
    {
        player.GetComponent<TestPlayerController>().enabled = false; // Teleports player back to teleportDestination
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = teleportDestination;
        player.GetComponent<TestPlayerController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Radiation"))
        {
            KillMe();
        }
    }
}
