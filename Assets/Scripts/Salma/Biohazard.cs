using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biohazard : MonoBehaviour
{
    //[SerializeField]
    //private GameObject puzzleManager;

    [SerializeField]

    private PuzzleManager puzzleManager;

    // Start is called before the first frame update
    void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (puzzleManager.gameWon == false)
        {
            puzzleManager.resetPuzzle();
            return;
        }
    }
}
