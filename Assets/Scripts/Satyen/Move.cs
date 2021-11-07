using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject lightObject;
    public float timeToWait;
    public float upperHeight;
    public float lowerHeight;
    public float movementSpeed;
    public float radiusSpeed;
    public GameObject lightSource;

    private Vector3 starting;
    private bool moving;
    private bool enlarging;
    private float timePassed;
    private float movement;
    private float radius;

    private void Start()
    {
        starting = lightObject.transform.position;
        moving = true;
        movement = 1f;
        radius = lightSource.GetComponent<SphereCollider>().radius;
    }


    public void Update()
    {
        if (moving)
        {
            lightObject.transform.position = new Vector3(0, movementSpeed * movement, 0) + starting;
            starting = lightObject.transform.position;
            lightSource.GetComponent<SphereCollider>().radius = radius + (movement * radiusSpeed);
            radius = lightSource.GetComponent<SphereCollider>().radius;
        }

        if (lightObject.transform.position.y < lowerHeight ||
            lightObject.transform.position.y > upperHeight)
        {
            timePassed += Time.deltaTime;
           if ( timePassed > timeToWait)
            {
                movement *= -1;
                moving = true;
                timePassed = 0;
            }
           else
            {
                moving = false;
            }
        }

    }
}
