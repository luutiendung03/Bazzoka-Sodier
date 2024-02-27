using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenStuff : Singleton<HiddenStuff>
{
    [SerializeField] List<GameObject> tabs;

    

    public void Show(int index)
    {
        Transform hiding;
        while (transform.childCount > 0)
        {
            hiding = transform.GetChild(0);
            Hide(hiding.gameObject);

        }
        foreach (GameObject tab in tabs)
        {
            tab.SetActive(false);
        }    

        Show(tabs[index]);
    }

    private void Show(GameObject showing)
    {
        showing.transform.SetParent(transform);
        //currentShow.Add(showing);
        showing.SetActive(true);
    }

    private void Hide(GameObject hiding)
    {
        hiding.transform.SetParent(transform.parent);
        hiding.SetActive(false);
    }    
}
