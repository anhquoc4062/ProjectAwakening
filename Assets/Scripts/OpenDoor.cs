using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public int scene;
    public bool isLocked;
    public Animator openAnim;
    public AudioSource openSound;
    public AudioSource lockedSound;

    public Player player;
    private PuzzleSystem puzzleSystem;
    // Start is called before the first frame update
    void Start()
    {
        openAnim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        puzzleSystem = gameObject.GetComponent<PuzzleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (puzzleSystem != null)
        {
            isLocked = !puzzleSystem.isSolved;
            if(isLocked == false)
            {
                GameObject.Find("Lock").GetComponent<SpriteRenderer>().sprite = GameObject.Find("opendoor").GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isLocked)
                {
                    StartCoroutine(openDoor());
                }
                else
                {
                    lockedSound.Play();
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isLocked)
                {
                    StartCoroutine(openDoor());
                }
                else
                {
                    lockedSound.Play();
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
    }

    IEnumerator openDoor()
    {
        openSound.Play();
        openAnim.Play("Door Open");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }
}
