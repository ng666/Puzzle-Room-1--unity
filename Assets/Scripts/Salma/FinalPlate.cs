using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlate : MonoBehaviour
{
    //[SerializeField]
    //private GameObject puzzleManager;

    [SerializeField]
    private PuzzleManager puzzleManager;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleManager.gameWon == true)
        {
            anim.SetTrigger("DoorOpen");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        //  {
        if (puzzleManager.numPressed < 30) // Oh no fail!
        {
            puzzleManager.resetPuzzle();
            return;
        }
        else
        {
            puzzleManager.gameWon = true;
            anim.SetTrigger("DoorOpen");
        }
        // }
    }
}
