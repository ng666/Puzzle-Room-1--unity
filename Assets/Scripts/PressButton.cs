using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    
    private bool activatable;
    [SerializeField]
    public GameObject debris;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
       
        activatable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && activatable)
        {
            debris.SetActive(false);
            gameObject.tag = "Finish";
            Text.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            activatable = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activatable = false;
        }
    }
}
