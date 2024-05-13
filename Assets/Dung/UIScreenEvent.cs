using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenEvent : Singleton<UIScreenEvent>
{
    //[SerializeField] private GameObject topArea;
    //[SerializeField] private GameObject belowArea;
    //[SerializeField] private GameObject rightArea;
    //[SerializeField] private GameObject leftArea;

    [SerializeField] private GameObject mainMenu;
    
    public void MenuOff()
    {
        //topArea.SetActive(false);
        //belowArea.SetActive(false);
        //rightArea.SetActive(false);
        //leftArea.SetActive(false);

        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuOn()
    {
        mainMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
