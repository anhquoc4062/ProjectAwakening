using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public GameObject puzzleObject;
    public bool isSolved;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (puzzleObject != null)
        {
            isSolved = puzzleObject.GetComponent<PuzzleSystem>().isSolved;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = !isSolved;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
