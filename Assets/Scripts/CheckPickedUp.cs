using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPickedUp : MonoBehaviour
{
    public GameObject pickupObject;
    private string name { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        name = pickupObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalManager.isPickuped[name] == true)
        {
            Destroy(pickupObject);
        }
    }
}
