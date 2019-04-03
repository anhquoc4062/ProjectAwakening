using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public int scene;
    public bool isLocked;
    //public Animator openAnim;
    public AudioSource openSound;
    public AudioSource lockedSound;

    public float playerPosition;

    public Player player;
    public string reactLocked;
    public GameObject puzzleObject;

    public GameObject changToIcon;
    // Start is called before the first frame update
    void Start()
    {
        //openAnim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (puzzleObject != null)
        {
            isLocked = !puzzleObject.GetComponent<PuzzleSystem>().isSolved;
            if(isLocked == false)
            {
                changToIcon.transform.localScale = puzzleObject.transform.localScale;
                puzzleObject.GetComponent<PuzzleSystem>().GetComponent<SpriteRenderer>().sprite = changToIcon.GetComponent<SpriteRenderer>().sprite;
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
                    if(lockedSound != null)
                    {
                        lockedSound.Play();
                    }
                    StartCoroutine(showText());
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
    }

    IEnumerator openDoor()
    {
        if(openSound != null)
        {
            openSound.Play();
        }
        //openAnim.Play("Door Open");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
        //spaw vi tri player
        player.transform.position = new Vector3(playerPosition, player.transform.position.y,0);
    }

    IEnumerator showText()
    {
        player.charText.text = reactLocked;
        yield return new WaitForSeconds(1f);
        player.charText.text = "";
    }
}
