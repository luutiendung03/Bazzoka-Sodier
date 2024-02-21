using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    public void OnOpened()
    {
        gameObject.SetActive(true);
    }

    public void OnClosed()
    {
        gameObject.SetActive(false);
    }
}
