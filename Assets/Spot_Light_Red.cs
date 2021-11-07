using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot_Light_Red : MonoBehaviour
{
    public bool player_casted = false;
    public bool rbox_covered = false;
    public bool rlight_stopped = false;
    private int counter = 0;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private GameObject box;

    private Vector3 startingPosition;
    private float phase = 0.0f;

    private void Start()
    {
        startingPosition = gameObject.transform.position;
    }

    private void Move()
    {
        phase += Time.deltaTime;
        Vector3 newPosition = startingPosition;
        newPosition.z = startingPosition.z + 7 * Mathf.Sin(speed * phase);
        gameObject.transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            counter = 1000;
            rlight_stopped = true;
        }

        if (counter == 0)
        {
            rlight_stopped = false;
            Move();
        }
        else
        {
            counter--;
        }

        Vector3 Light2Player = (player.transform.position - transform.position).normalized;
        Vector3 Light2Box = (box.transform.position - transform.position).normalized;

        Ray ray_1 = new Ray(transform.position, Light2Player);
        Ray ray_2 = new Ray(transform.position, Light2Box);
        RaycastHit hit_1; 
        RaycastHit hit_2;
        if (Physics.Raycast(ray_1, out hit_1))
        {
            if (hit_1.collider.gameObject.CompareTag("Player"))
                player_casted = true;
            else
                player_casted = false;
        }
        if (Physics.Raycast(ray_2, out hit_2))
        {
            if (hit_2.collider.gameObject.CompareTag("box_red"))
                rbox_covered = false;
            else
                rbox_covered = true;
        }
    }
}
