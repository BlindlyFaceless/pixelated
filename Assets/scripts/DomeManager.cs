using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeManager : MonoBehaviour
{
    #region Singleton

    public static DomeManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject dome;
}
