﻿using System.Collections;
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
        objectBeingDragged = gameObject;
        startPosition = transform.position;
        distanceToCamera = Mathf.Abs(startPosition.z - Camera.main.transform.position.z) - 0.01f;
        objectBeingDragged.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    // called every frame the user drags this gameobject
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        // update position
        objectBeingDragged.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                                            Input.mousePosition.y,
                                                                                            distanceToCamera));
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    // called when there has been a drag and the user lets go
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // check here for "am i close enough to where I'm meant to be"

        // if not "where I'm supposed to be" reset
        if(objectName + "_puzzle" == puzzleObject.name && puzzleObject != null)
        {
            gameObject.name = "Slot (" +position+")";
            gameObject.GetComponent<Image>().sprite = GameObject.Find("Slot Empty").GetComponent<SpriteRenderer>().sprite;
            inventory.isFull[position - 1] = false;

        }
        else
        {
            StartCoroutine(showText());
        }
        objectBeingDragged.transform.position = startPosition;
        objectBeingDragged.layer = LayerMask.NameToLayer("Default");
        objectBeingDragged = null;
        this.GetComponent<BoxCollider2D>().enabled = false;

    }

    IEnumerator showText()
    {
        player.charText.text = "Không có gì xảy ra cả";
        yield return new WaitForSeconds(1f);
        player.charText.text = "";
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        puzzleObject = col.gameObject;
    }



}