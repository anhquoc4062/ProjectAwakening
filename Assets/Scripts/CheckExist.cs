using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExist : MonoBehaviour
{
    public GameObject disObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalManager.isPickuped[disObject.name] == false)
        {
            disObject.SetActive(true);
            disObject.GetComponent<Pickup>().enabled = true;
        }
        else
        {

            disObject.SetActive(false);
            disObject.GetComponent<Pickup>().enabled = true;
        }
    }
}
