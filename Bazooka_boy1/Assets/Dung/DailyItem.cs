using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyItem : MonoBehaviour
{
    [SerializeField] private GameObject shadow;
    [SerializeField] private GameObject selectingPane;
    [SerializeField] private GameObject dailyPane;
    [SerializeField] private GameObject tickV;

    public void SingleShow(int dailyClaimed)
    {
        if(dailyClaimed == 0)
        {
            tickV.SetActive(true);
            shadow.SetActive(false);
            dailyPane.SetActive(true);
            selectingPane.SetActive(false);
        }
        else if(dailyClaimed == 1)
        {
            tickV.SetActive(false);
            shadow.SetActive(false);
            dailyPane.SetActive(false);
            selectingPane.SetActive(true);
        }
        else if(dailyClaimed == 2)
        {
            tickV.SetActive(false);
            shadow.SetActive(true);
            dailyPane.SetActive(true);
            selectingPane.SetActive(false);
        }
    }

}
