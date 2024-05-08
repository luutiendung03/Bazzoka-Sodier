using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : Singleton<UIManager>
{
    public static UIManager Instance;

    //[SerializeField] GameObject cameraEndGame;

    public int rate = 0;
    

    [SerializeField] private UIScreen[] screens;

    [Header("Panel UI")]
    public LosePopup lose_Dead;
    public LosePopup lose_OutOfBullet;
    //public WinPopup winPopup;
    public WinProgress winProgress;
    public WinBonus winBonus;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        foreach(UIScreen screen in screens)
        {
            screen.gameObject.SetActive(false);
        }
        
        
    }

    private void Update()
    {
       
        if (rate == 5)
        {
            if (PlayerPersistentData.Instance.RateGame == 0)
            {
                screens[6].gameObject.SetActive(true);
            }
            rate = 0;
        }
    }
}
