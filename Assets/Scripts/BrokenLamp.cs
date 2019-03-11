using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLamp : MonoBehaviour
{
    public AudioSource brokenLampSound;
    
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
        brokenLampSound.Play();
    }
    private void OnTriggerStay2D(Collider2D col) { 
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        brokenLampSound.Stop();
    }
}
