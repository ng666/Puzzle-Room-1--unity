using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    public Material[] materialArray; // Stores the 2 materials of the plate

    private PuzzleManager puzzleManager; // Points to puzzleManager to update the state of the puzzle
    private bool isPressed; // has this plate been pressed or not?

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        puzzleManager = FindObjectOfType<PuzzleManager>();
        gameObject.GetComponent<MeshRenderer>().material = materialArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleManager.gameLost && isPressed) // If the player loses and the plate is pressed, unpress the plate
        {
            isPressed = false;
            gameObject.GetComponent<MeshRenderer>().material = materialArray[0];
            puzzleManager.numPressed--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (puzzleManager.mostRecentPlate != this) // Don't do anything for consecutive presses on the same plate
        {
            if (isPressed) // If pressed
            {
                if (puzzleManager.gameWon == false)
                {
                    puzzleManager.resetPuzzle();
                    return;
                }
            }
            isPressed = true;
            puzzleManager.mostRecentPlate = this;
            puzzleManager.numPressed++;
            gameObject.GetComponent<MeshRenderer>().material = materialArray[1];
        }
    }
}