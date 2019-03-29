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
    public string objectName;
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

    // called when there has been a drag and the user lets go
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // check here for "am i close enough to where I'm meant to be"

        // if not "where I'm supposed to be" reset
        if (puzzleObject != null)
        {

            
            if (objectName + "_puzzle" == puzzleObject.name)
            {
                gameObject.name = "Slot (" + position + ")";
                gameObject.GetComponent<Image>().sprite = GameObject.Find("Slot Empty").GetComponent<SpriteRenderer>().sprite;
                inventory.isFull[position - 1] = false;
                puzzleObject.GetComponent<PuzzleSystem>().isSolved = true;
                puzzleObject.GetComponent<PuzzleSystem>().puzzleSound.Play();
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
        puzzleObject = col.gameObject;
        Debug.Log(puzzleObject.name);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Puzzle"))
        {
            puzzleObject = col.gameObject;
            Debug.Log(puzzleObject.name);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        puzzleObject = null;
        Debug.Log("null");
    }



}