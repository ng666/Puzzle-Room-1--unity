using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private bool moot;
    // Start is called before the first frame update
    void Start()
    {
        moot = true;
        StartCoroutine(LightCycle());
    }


    IEnumerator LightCycle()
    {
        while (moot)
        {
            yield return new WaitForSeconds(1);
            gameObject.SetActive(true);
            Debug.Log("1");
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
            Debug.Log("2");
            Debug.Log("3");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
