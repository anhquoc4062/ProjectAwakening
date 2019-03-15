using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafe : MonoBehaviour
{
    public GameObject safe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (col.CompareTag("Player"))
            {
                if(safe.activeSelf == false)
                {
                    safe.SetActive(true);
                }
                else
                {
                    safe.SetActive(false);
                }
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (col.CompareTag("Player"))
            {
                if (safe.activeSelf == false)
                {
                    safe.SetActive(true);
                }
                else
                {
                    safe.SetActive(false);
                }
            }
        }

    }
}
