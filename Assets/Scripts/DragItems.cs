using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItems : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    Vector3 oldLocation;

    private static GameObject objectBeingDragged;
    public int position;
    private Vector3 startPosition;
    private Vector3 startSize;
    private float distanceToCamera;
    private GameObject puzzleObject;
    private string objectName;
    public string keyName;
    private Inventory inventory;
    private Player player;
    // called the first time the user clicks and drags on this gameobject

    char GetPositionByName(string name)
    {
        return name[name.Length - 2];
    }
    void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        position = int.Parse(GetPositionByName(gameObject.name).ToString());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        objectName = gameObject.name;
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        player.r2.isKinematic = true;
        objectBeingDragged = gameObject;
        startPosition = transform.position;
        startSize = transform.localScale;
        distanceToCamera = Mathf.Abs(startPosition.z - Camera.main.transform.position.z) - 0.01f;

        objectBeingDragged.transform.localScale = new Vector3(objectBeingDragged.transform.localScale.z / 2, objectBeingDragged.transform.localScale.z / 2, objectBeingDragged.transform.localScale.z / 2);
        objectBeingDragged.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    // called every frame the user drags this gameobject
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        player.r2.isKinematic = true;
        // update position
        objectBeingDragged.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                                            Input.mousePosition.y,
                                                                                            distanceToCamera));
        
        if (!this.gameObject.name.Contains("Slot")) {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void solve()
    {
        gameObject.name = "Slot (" + position + ")";
        gameObject.GetComponent<Image>().sprite = GameObject.Find("Slot Empty").GetComponent<SpriteRenderer>().sprite;
        inventory.isFull[position - 1] = false;
        if (keyName != "Sprite")
        {
            //puzzleObject.GetComponent<PuzzleSystem>().isSolved = true;
            if (puzzleObject.GetComponent<PuzzleSystem>().puzzleSound != null)
            {
                puzzleObject.GetComponent<PuzzleSystem>().puzzleSound.Play();
            }

        }
        else
        {
            if(GlobalManager.countSquired == 0)
            {
                StartCoroutine(showText());
                objectBeingDragged.transform.position = startPosition;
                objectBeingDragged.transform.localScale = startSize;
                objectBeingDragged.layer = LayerMask.NameToLayer("Default");
                objectBeingDragged = null;
                this.GetComponent<BoxCollider2D>().enabled = false;

                player.r2.isKinematic = false;
            }
            else
            {
                GlobalManager.countSquired = 0;
            }
        }
        if (puzzleObject != null)
        {
            GlobalManager.isSolved[puzzleObject.name] = true;
        }
        /*if (puzzleObject.name == "fire_puzzle" && GlobalManager.isSolved["fire_puzzle"] == true)
        {
            puzzleObject.name = "doll01_puzzle";
        }*/
        //Debug.Log(puzzleObject.name + "_called");
        //Debug.Log(GlobalManager.isSolved[puzzleObject.name]);
    }

    // called when there has been a drag and the user lets go
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // check here for "am i close enough to where I'm meant to be"

        // if not "where I'm supposed to be" reset
        if (puzzleObject != null)
        {
            if (keyName == puzzleObject.name)
            {
                if (puzzleObject.name != "fire_puzzle")
                {
                    solve();
                }
                else
                {
                    if (GlobalManager.isSolved["fire_puzzle"] == false)
                    {
                        if (gameObject.name.Substring(0, 4) != "doll")
                        {
                            solve();
                        }
                        else
                        {
                            StartCoroutine(showText());

                        }
                    }
                    else
                    {
                        if (gameObject.name.Substring(0, 4) == "doll")
                        {
                            int index = int.Parse(gameObject.name.Substring(5, 1)) + 1;
                            solve();
                            GlobalManager.countDollBurned++;
                            GameObject.Find("Scream").GetComponent<AudioSource>().Play();
                            Debug.Log("So bup be dot duoc "+GlobalManager.countDollBurned);

                            if (index < 6)
                            {
                                string name = "doll0" + index;
                                GlobalManager.isPickuped[name] = false;

                                Debug.Log(GlobalManager.isPickuped[name]);
                            }
                        }
                    }
                }
               
            }
            else
            {

                StartCoroutine(showText());
            }
        }
        
        else
        {
            StartCoroutine(showText());
        }
        objectBeingDragged.transform.position = startPosition;
        objectBeingDragged.transform.localScale = startSize;
        objectBeingDragged.layer = LayerMask.NameToLayer("Default");
        objectBeingDragged = null;
        this.GetComponent<BoxCollider2D>().enabled = false;

        player.r2.isKinematic = false;
    }

    IEnumerator showText()
    {
        player.charText.text = "NOTHING HAPPENED";
        yield return new WaitForSeconds(1f);
        player.charText.text = "";
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.name.Length > 6)
        {
            if (gameObject.name.Substring(0, 7) == "bandage")
            {
                if (col.CompareTag("Player"))
                {
                    puzzleObject = col.gameObject;
                    Debug.Log(puzzleObject.name);
                }
            }
            else
            {
                if (col.CompareTag("Puzzle"))
                {
                    puzzleObject = col.gameObject;
                    Debug.Log(puzzleObject.name);
                }
            }
        }
        else
        {
            if (col.CompareTag("Puzzle"))
            {
                puzzleObject = col.gameObject;
                Debug.Log(puzzleObject.name);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(gameObject.name.Length > 6)
        {
            if (gameObject.name.Substring(0, 7) == "bandage")
            {
                if (col.CompareTag("Player"))
                {
                    puzzleObject = col.gameObject;
                    Debug.Log(puzzleObject.name);
                }
            }
            else
            {
                if(col.CompareTag("Puzzle")){
                    puzzleObject = col.gameObject;
                    Debug.Log(puzzleObject.name);
                }
            }
        }
        else
        {
            if(col.CompareTag("Puzzle"))
            {
                puzzleObject = col.gameObject;
                Debug.Log(puzzleObject.name);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        puzzleObject = null;
    }



}