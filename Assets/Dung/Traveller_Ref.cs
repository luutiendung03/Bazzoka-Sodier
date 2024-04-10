using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveller_Refs : Singleton<Traveller_Refs>
{
    [SerializeField] private List<GameObject> hidertonList;
    [SerializeField] internal UIScreen rewardFailedPopUp;

    public T GetHiderton<T>() where T : MonoBehaviour
    {
        foreach (GameObject obj in hidertonList)
        {
            if (obj.TryGetComponent<T>(out T component))
            {
                return component;
            }
        }
        Debug.Log("Put Hiderton of " + typeof(T).Name + " in the Resource Manager!");
        return null;
    }
}
