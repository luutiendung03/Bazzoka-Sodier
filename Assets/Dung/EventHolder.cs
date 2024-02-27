using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class EventHolder : InfoLoad, IPointerClickHandler, IPointerDownHandler, IPointerExitHandler
{
    protected float popUpScale = 1.1f;

    protected float popDownScale = 0.9f;

    protected GameObject holding;

    protected bool wasDragging;

    [SerializeField] private bool ignoreDragProctector;
    //[SerializeField] private ClickSoundType defaultClick; //, firstItemClick, secondItemClick, thirdItemClick;

    protected abstract bool ClickAction(PointerEventData eventData, GameObject clicked);
    protected virtual void Up(Transform holding)
    {
        holding.transform.localScale = Vector3.one;
    }
    protected virtual void Down(Transform holding)
    {
        holding.transform.localScale = Vector3.one * popDownScale;
    }


    private Action callback;
    public void OnPointerClickCallback(PointerEventData eventData = null, Action callback = null)
    {
        this.callback = callback;
        if (eventData != null)
        {
            OnPointerClick(eventData);
        }
    }

    public void AddCallback(Action callback)
    {
        this.callback += callback;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clicked = eventData.pointerCurrentRaycast.gameObject;

        if (clicked.tag == "EventHolder")
        {
            if (holding != null)
            {
                Up(holding.transform);
                holding = null;
            }
        }
        else if (clicked != holding)
        {
            if (holding != null) Up(holding.transform);
            holding = clicked;
        }
        else
        {
            Up(holding.transform);
            holding = null;
            if (ignoreDragProctector || !wasDragging)
            {
                if (ClickAction(eventData, clicked))
                {
                    //AudioController.Instance.ClickButton(defaultClick);
                    //Debug.Log(this.GetType()); 
                }
                if (callback != null)
                {
                    //Debug.Log("Kekw"); 
                    callback();
                    callback = null;
                }
                //Debug.Log("Click: " + clicked.name);
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject downed = eventData.pointerCurrentRaycast.gameObject;
        //Debug.Log("Down: " + downed.tag);
        if (downed.tag != "EventHolder")
        {
            holding = downed;
            Down(holding.transform);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (holding != null)
        {
            Up(holding.transform);
        }
        holding = null;
    }
}
