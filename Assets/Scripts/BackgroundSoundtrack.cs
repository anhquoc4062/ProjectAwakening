using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundtrack : MonoBehaviour
{
    public AudioSource regular;
    public AudioSource agressive;
    public AudioSource heart;
    // Start is called before the first frame update
    void Start()
    {
        regular.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalManager.countSquired > 0)
        {
            if (!heart.isPlaying)
            {
                heart.Play();
            }
        }
        else
        {
            if (heart.isPlaying)
            {
                heart.Stop();
            }
        }

        if(GlobalManager.meetPlayer == true)
        {
            if (!agressive.isPlaying)
            {
                agressive.Play();
            }
        }
        else
        {
            if (agressive.isPlaying)
            {
                agressive.Stop();
            }
        }
    }
}
