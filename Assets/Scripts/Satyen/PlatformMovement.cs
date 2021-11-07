using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject upCycle;
    public GameObject downCycle;
    public GameObject horizontalPlatformOne;
    public GameObject horizontalPlatformTwo;

    
    public float timeToWait;
    public float timeToWaitHorizontal;
    public float upperHeight;
    public float lowerHeight;
    public float horizontalOneLower;
    public float horizontalOneUpper;
    public float movementSpeed;
    public float horizontalMovementSpeed;

    private Vector3 startingUp;
    private Vector3 startingDown;
    private Vector3 startingHorizontalOne;
    private Vector3 startingHorizontalTwo;
    private Vector3 actStartUp;
    private Vector3 actStartHorizontal;
    private bool moving;
    private bool movingHorizontal;
    private float timePassed;
    private float horizontalTimePassed;
    private float movement;
    private float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        startingUp = upCycle.transform.position;
        startingDown = downCycle.transform.position;
        actStartUp = startingUp;
        startingHorizontalOne = horizontalPlatformOne.transform.position;
        startingHorizontalTwo = horizontalPlatformTwo.transform.position;
        actStartHorizontal = startingHorizontalOne;
        
        moving = true;
        movingHorizontal = true;
        timePassed = 0f;
        horizontalTimePassed = 0f;
        movement = 1f;
        horizontalMovement = 1f;
    }

    private void FixedUpdate()
    {
        //Debug.Log(upCycle.transform.position.y);
        if (moving)
        {
            upCycle.transform.position = new Vector3(0, movementSpeed * movement, 0) + startingUp;
            downCycle.transform.position = new Vector3(0, movementSpeed * movement * -1, 0) + startingDown;
            startingUp = upCycle.transform.position;
            startingDown = downCycle.transform.position;
        }

        if (upCycle.transform.position.y - actStartUp.y < lowerHeight ||
            upCycle.transform.position.y - actStartUp.y > upperHeight)
        {
            timePassed += Time.deltaTime;
            if (timePassed > timeToWait)
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

        if (movingHorizontal)
        {
            horizontalPlatformOne.transform.position = new Vector3(horizontalMovementSpeed * horizontalMovement, 0, 0) + startingHorizontalOne;
            startingHorizontalOne = horizontalPlatformOne.transform.position;
            horizontalPlatformTwo.transform.position = new Vector3(0, 0, horizontalMovementSpeed * horizontalMovement * -1) + startingHorizontalTwo;
            startingHorizontalTwo = horizontalPlatformTwo.transform.position;

        }

        if (horizontalPlatformOne.transform.position.x - actStartHorizontal.x < horizontalOneLower ||
            horizontalPlatformOne.transform.position.x - actStartHorizontal.x > horizontalOneUpper)
        {
            horizontalTimePassed += Time.deltaTime;
            if (horizontalTimePassed > timeToWait)
            {
                horizontalMovement *= -1;
                movingHorizontal= true;
                horizontalTimePassed = 0;
            }
            else
            {
                movingHorizontal = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
