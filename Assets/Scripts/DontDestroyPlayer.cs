using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
    private static bool objectExist = false;
    void Awake()
    {
        if (objectExist == true)
        {
            Destroy(gameObject);
        }
        else
        {
            objectExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
