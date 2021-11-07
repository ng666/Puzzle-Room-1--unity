using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private CountDownBar countdown;
    public AudioSource SlowHeartbeat;
    public AudioSource MediumHeartbeat;
    public AudioSource FastHeartbeat;
    // Start is called before the first frame update
    void Start()
    {
        countdown = FindObjectOfType<CountDownBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.getHealth() <= 100 && countdown.getHealth() > 66)  //these values are arbitrary. we will reassign them once we decide how long we want our timer to be.
        {
            if(!SlowHeartbeat.isPlaying && !MediumHeartbeat.isPlaying && !FastHeartbeat.isPlaying)
            {
                SlowHeartbeat.Play();
            }
        }
        if (countdown.getHealth() <= 66 && countdown.getHealth() > 33)
        {
            if (!SlowHeartbeat.isPlaying && !MediumHeartbeat.isPlaying && !FastHeartbeat.isPlaying)
            {
                MediumHeartbeat.Play();
            }
        }
        if (countdown.getHealth() <= 33 && countdown.getHealth() > 0)
        {
            if (!SlowHeartbeat.isPlaying && !MediumHeartbeat.isPlaying && !FastHeartbeat.isPlaying)
            {
                FastHeartbeat.Play();
            }
        }

    }
}
