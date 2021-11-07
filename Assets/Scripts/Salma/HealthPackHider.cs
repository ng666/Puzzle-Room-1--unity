using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackHider : MonoBehaviour
{
    // Start is called before the first frame update
    private PuzzleManager puzzleManager; // Points to puzzleManager to update the state of the puzzle
    [SerializeField]
    GameObject healthpack;
    void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        healthpack.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleManager.gameWon == true)
        {
            healthpack.GetComponent<Renderer>().enabled = true;
        }
    }
}
