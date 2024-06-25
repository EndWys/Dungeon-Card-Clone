using Assets.GameCore.GamePlay.Currencies;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseManager<T> where T : BaseManager<T>, new()
{
    public static T _instance;
    public static T Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = new();
            }

            return _instance;
        }
    }
}
