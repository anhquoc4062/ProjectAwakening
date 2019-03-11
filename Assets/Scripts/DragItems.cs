using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItems : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    Vector3 oldLocation;

    public static GameObject objectBeingDragged;
    public Vector3 startPosition;
    public float distanceToCamera;

    // called the first time the user clicks and drags on this gameobject
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
        //this.GetComponent<BoxCollider2D>().enabled = true;
    }

    // called when there has been a drag and the user lets go
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // check here for "am i close enough to where I'm meant to be"

        // if not "where I'm supposed to be" reset
        //objectBeingDragged.transform.position = startPosition;
        //objectBeingDragged.layer = LayerMask.NameToLayer("Default");
        //objectBeingDragged = null;
        
        //this.GetComponent<BoxCollider2D>().enabled = false;
    }


}