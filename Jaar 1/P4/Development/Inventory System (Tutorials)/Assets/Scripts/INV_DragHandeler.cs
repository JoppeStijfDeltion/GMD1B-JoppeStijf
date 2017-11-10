using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class INV_DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    //staat op elk item
    public static GameObject itemBeingDragged;
    public Vector3 startPosition;
    public Transform startParent;

    //begin met slepen + item dat je sleept in itemBeingDragged gestopt en word er voor gezorgd dat de startPostion word vastgesteld
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        gameObject.transform.SetParent(startParent);
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //wanneer je aan het slepen bent blijft het item dat je aan het slepen bent op de positie van de muis
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    //wanneer je ophoud met slepen word itemBeingDragged gereset en word de huidige positie opgeslagen in startPosition
    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent != startParent)
        {
            transform.position = startPosition;
        }
    }
}
