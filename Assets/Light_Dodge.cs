using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Dodge : MonoBehaviour
{
    private float player_hp;
    private Spot_Light_Red rcasted;
    private Spot_Light_Green gcasted;
    public bool in_red = false;
    public bool in_green = false;
    private TestPlayerController playerControl;
    private int counter;
    private float previous_speed = 0;
    private bool speed_recovered = true;
    private bool speed_get = false;
    private bool despeeded = true;
    private bool upspeeded = false;
    // Start is called before the first frame update
    void Start()
    {
        player_hp = 10;
        counter = 60;
        playerControl = GameObject.Find("Player").GetComponent<TestPlayerController>();
        rcasted = GameObject.Find("SpotLight_Red").GetComponent<Spot_Light_Red>();
        gcasted = GameObject.Find("SpotLight_Green").GetComponent<Spot_Light_Green>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 600)
        {
            if (InRed() && rcasted.player_casted)
            {
                player_hp--;
            }
            else if (InGreen() && gcasted.player_casted)
            {
                player_hp--;
            }
            counter = 0;
        }
        else
        {
            counter++;
        }

        if (InRed())
        {
            in_red = true;
            in_green = false;
            if (!rcasted.rlight_stopped)
            {
                if (!speed_recovered)
                {
                    playerControl.setSpeed(previous_speed);
                    speed_recovered = true;
                    speed_get = false;
                }

                if (rcasted.player_casted && !despeeded)
                {
                    playerControl.deSpeed(5.0f);
                    despeeded = true;
                    upspeeded = false;
                }
                else if (!rcasted.player_casted && !upspeeded)
                {
                    playerControl.upSpeed(5.0f);
                    upspeeded = true;
                    despeeded = false;
                }
            }
            else if (!speed_get)
            {
                previous_speed = playerControl.getSpeed();
                speed_get = true;
                playerControl.setSpeed(0);
                speed_recovered = false;
            }
        }

        else if (InGreen())
        {
            in_red = false;
            in_green = true;
            if (!gcasted.glight_stopped)
            {
                if (!speed_recovered)
                {
                    playerControl.setSpeed(previous_speed);
                    speed_recovered = true;
                    speed_get = false;
                }

                if (gcasted.player_casted && !despeeded)
                {
                    playerControl.deSpeed(5.0f);
                    despeeded = true;
                    upspeeded = false;
                }
                else if (!gcasted.player_casted && !upspeeded)
                {
                    playerControl.upSpeed(5.0f);
                    upspeeded = true;
                    despeeded = false;
                }
            }
            else if (!speed_get)
            {
                previous_speed = playerControl.getSpeed();
                speed_get = true;
                playerControl.setSpeed(0);
                speed_recovered = false;
            }
        }

    }

    void OnGUI()
    {
        if (gameObject.transform.position.y < -40)
        {
            GUI.Label(new Rect(Screen.width - 100, Screen.height - 50, 155, 30), "Player HP: " + player_hp);
            GUI.Label(new Rect(Screen.width - 200, Screen.height - 300, 155, 60), "Hide under the shadow to survive");
            GUI.Label(new Rect(Screen.width - 200, Screen.height - 150, 155, 60), "Press 'Q' and 'E' to stop light movement");
        }
    }

    private bool InRed()
    {
        if (gameObject.transform.position.x > 96)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool InGreen()
    {
        if (gameObject.transform.position.x < 96)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
