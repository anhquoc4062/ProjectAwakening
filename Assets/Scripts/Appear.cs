using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject puzzleObject;
    public bool isSolved;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
         isSolved = gameObject.GetComponent<PuzzleSystem>().isSolved;
    }

    // Update is called once per frame
    void Update()
    {
        puzzleObject.SetActive(isSolved);
    }
}
