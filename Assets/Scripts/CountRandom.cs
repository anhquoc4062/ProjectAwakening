using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountRandom : MonoBehaviour
{
    private float view;
    public int viewRandom;
    // Start is called before the first frame update
    void Start()
    {
        view = 0;
        viewRandom = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        view += Time.deltaTime;
        if(view > 2)
        {
            viewRandom = Random.Range(1, 4);
            view = 0;
        }
    }
}
