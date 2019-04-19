using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSystem : MonoBehaviour
{
    public AudioSource puzzleSound;
    public bool isSolved;
    // Start is called before the first frame update
    void Awake()
    {
        if(GlobalManager.isSolved[gameObject.name] == false)
        {
            isSolved = false;
        }
        else
        {
            isSolved = true;
        }
        Debug.Log("Awake called");
        Debug.Log(gameObject.name +"puzzle");
        Debug.Log(GlobalManager.isSolved[gameObject.name]);
    }
    void Start()
    {
        if (GlobalManager.isSolved[gameObject.name] == false)
        {
            isSolved = false;
        }
        else
        {
            isSolved = true;
        }
        Debug.Log(GlobalManager.isSolved[gameObject.name]);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalManager.isSolved[gameObject.name] == false)
        {
            isSolved = false;
        }
        else
        {
            isSolved = true;
        }
    }
}
