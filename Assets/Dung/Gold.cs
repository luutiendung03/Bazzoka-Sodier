using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    [SerializeField] private Text coinTxt;

    private void Update()
    {
        coinTxt.text = PlayerPersistentData.Instance.Gold.ToString();
    }

    
}
