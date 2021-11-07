using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public PressurePlate mostRecentPlate; // Points to the most recently-stepped on pressure plate

    [SerializeField]
    private Transform teleportDestination;

    public int numPressed;
    [SerializeField]
    public bool gameWon;

    public bool gameLost;

    // Start is called before the first frame update
    void Start()
    {
        numPressed = 0;
        player = GameObject.Find("Player");
        mostRecentPlate = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (numPressed >= 30)
        {
            gameWon = true;
            // stuff
        }
        if (gameLost && numPressed == 0)
        {
            gameLost = false;
            mostRecentPlate = null;
        }
    }

    public void resetPuzzle()
    {
        //numPressed = 0;
        gameLost = true;
        player.GetComponent<TestPlayerController>().enabled = false; // Teleports player back to teleportDestination
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = teleportDestination.position;
        player.GetComponent<TestPlayerController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
    }
}