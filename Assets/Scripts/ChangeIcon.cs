using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIcon : MonoBehaviour
{
    public GameObject iconChanged;
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
        if(isSolved == true)
        {
            iconChanged.transform.localScale = gameObject.transform.localScale;
            gameObject.GetComponent<SpriteRenderer>().sprite = iconChanged.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
