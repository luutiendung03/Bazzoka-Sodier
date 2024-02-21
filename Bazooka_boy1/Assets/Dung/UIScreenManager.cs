using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenManager : MonoBehaviour
{
    public static UIScreenManager Instance;

    [SerializeField] public List<UIScreen> screens;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        foreach (UIScreen screen in screens)
        {
            screen.gameObject.SetActive(false);
        }
        //screens[0].gameObject.SetActive(true);
    }
}
