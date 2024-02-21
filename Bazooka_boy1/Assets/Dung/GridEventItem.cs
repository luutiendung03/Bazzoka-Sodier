using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class GridItemEvent : EventHolder, /*IPointerClickHandler, IPointerDownHandler, IPointerExitHandler,*/ IBeginDragHandler, IEndDragHandler
{
    [SerializeField] protected RectTransform horiGrid;

    [SerializeField] protected GridLayoutGroup horiGridProp;

    public RectTransform HoriGrid { get => horiGrid; }

    public abstract void LoadItems();

    public abstract T GetItemById<T>(int id) where T : GridItem;

    protected override abstract bool ClickAction(PointerEventData eventData, GameObject clicked);
    protected abstract void UpAction(Transform holding);
    protected abstract void DownAction(Transform holding);

    protected override void Up(Transform holding)
    {
        UpAction(holding);
    }

    protected override void Down(Transform holding)
    {
        DownAction(holding);
    }

    protected virtual void DragEndAction(PointerEventData eventData)
    {
        wasDragging = false;
    }

    protected virtual void DragStartAction(PointerEventData eventData)
    {
        wasDragging = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragStartAction(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragEndAction(eventData);
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    GameObject clicked = eventData.pointerCurrentRaycast.gameObject;        
    //    if (clicked.tag == "EventHolder")
    //    {
    //        if (holding != null)
    //        {
    //            UpAction(holding.transform);
    //            holding = null;
    //        }
    //    }
    //    else if (clicked != holding)
    //    {
    //        if (holding != null) UpAction(holding.transform);
    //        holding = clicked;
    //    }
    //    else
    //    {
    //        UpAction(holding.transform);
    //        holding = null;
    //        if (!wasDragging)
    //        {
    //            ClickAction(eventData, clicked);
    //            Debug.Log("Click: " + clicked.name);
    //        }
    //    }
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    GameObject downed = eventData.pointerCurrentRaycast.gameObject;
    //    //Debug.Log("Down: " + downed.tag);
    //    if (downed.tag != "EventHolder")
    //    {
    //        holding = downed;
    //        DownAction(holding.transform);
    //    }       
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    if (holding != null)
    //    {
    //        UpAction(holding.transform);
    //    }
    //    holding = null;
    //}


}
