using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Vector3 displacement;
    [SerializeField]
    private float rotation = 0;
    [SerializeField]
    private float angularSpeed = 0.1f;
    [SerializeField]
    private float cameraSpeed = 10.0f;

    [SerializeField]
    private GameObject player;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rotation += angularSpeed;
        }
        if (Input.GetKey(KeyCode.C))
        {
            rotation -= angularSpeed;
        }
        Vector3 finalDisplacement = Quaternion.Euler(0, rotation, 0) * displacement;
        // Direct update
        //gameObject.transform.position = player.transform.position + finalDisplacement;
        Vector3 newPosition = player.transform.position + finalDisplacement;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPosition, cameraSpeed);
        gameObject.transform.LookAt(player.transform, Vector3.up);
    }
}
