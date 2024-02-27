using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopTab_InfoLoad : EventHolder
{
    [SerializeField] private HiddenStuff mainPanels;

    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        Load(clicked.transform.GetSiblingIndex());
        Debug.Log(clicked.transform.GetSiblingIndex());
        return true;
    }

    public void Load(int tabIndex)
    {
        Load(tabIndex, true);
    }

    public void Load(int tabIndex, bool isHomeBtn)
    {
        mainPanels.Show(tabIndex);
    }
}
