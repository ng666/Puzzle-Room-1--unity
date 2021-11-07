using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField]
    public CountDownBar countdownbar;

    // Start is called before the first frame update
    void Start()
    {
        showHealthPack();
        countdownbar = FindObjectOfType<Canvas>().GetComponentInChildren<CountDownBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player") // <<< Something like this
        //{
            gameObject.SetActive(false);
        //}

        countdownbar.changeHealth(5);
    }

    public void showHealthPack()
    {
        gameObject.SetActive(true);
    }
}
