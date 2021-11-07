using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnExit : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player.position.y <= 5.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
