using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RateUs : EventHolder
{
    private int ratePoint = 0;
    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        ShowStar(clicked.transform.GetSiblingIndex());
        return true;
    }

    private void ShowStar(int index)
    {
        for(int i = 0; i<=4; i++)
        {
            if(i<= index)
                transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
            else
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        ratePoint = index + 1;
    }

    public void Rate()
    {
        if(ratePoint > 3)
        {
            SkygoBridge.Instance.RateGame();

        }
        PlayerPersistentData.Instance.RateGame = 1;
        Debug.Log(ratePoint);
        
    }    
}
