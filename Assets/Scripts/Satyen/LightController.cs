using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public GameObject blueLight;
    public GameObject redLight;
    public GameObject greenLight;
    public GameObject yellowLight;
    public GameObject lightBlueLight;
    public GameObject purpleLight;

    public List<int> turnedWheels = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        blueLight.SetActive(true);
        greenLight.SetActive(false);
        yellowLight.SetActive(false);
        purpleLight.SetActive(false);
        redLight.SetActive(false);
        lightBlueLight.SetActive(false);
        StartCoroutine(LightCycle());
        turnedWheels.Add(0);
    }


    private void FixedUpdate()
    {
        //Debug.Log(turnedWheels[turnedWheels.Count - 1]);
        if( (int)(turnedWheels[turnedWheels.Count - 1]) == 6 &&
            (int)(turnedWheels[turnedWheels.Count - 2]) == 5 &&
            (int)(turnedWheels[turnedWheels.Count - 3]) == 4 &&
            (int)(turnedWheels[turnedWheels.Count - 4]) == 3 &&
            (int)(turnedWheels[turnedWheels.Count - 5]) == 2 &&
            (int)(turnedWheels[turnedWheels.Count - 6]) == 1)
        {
            Debug.Log("DONE!!!!11!1");
            gameObject.transform.position = new Vector3(116.71f, -49f, 113.02f);
            turnedWheels.Add(0);
        }
    }

    IEnumerator LightCycle()
    {
        while (true)
        {
            blueLight.SetActive(false);
            greenLight.SetActive(true);
            yield return new WaitForSeconds(2);
            greenLight.SetActive(false);
            yellowLight.SetActive(true);
            yield return new WaitForSeconds(2);
            yellowLight.SetActive(false);
            purpleLight.SetActive(true);
            yield return new WaitForSeconds(2);
            purpleLight.SetActive(false);
            redLight.SetActive(true);
            yield return new WaitForSeconds(2);
            redLight.SetActive(false);
            lightBlueLight.SetActive(true);
            yield return new WaitForSeconds(2);
            lightBlueLight.SetActive(false);
            yield return new WaitForSeconds(5);
            blueLight.SetActive(true);
            yield return new WaitForSeconds(2);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
