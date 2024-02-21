using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                //if (instance == null) Debug.Log("Turn on the " + typeof(T).ToString() + "!");
            }
            return instance;
        }
    }

    public static void SetInstanceBrutely(T t)
    {
        instance = t;
    }

    public static Action promiseAction;

    private void Awake()
    {
        if (promiseAction != null) promiseAction();
        promiseAction = null;
    }
}
