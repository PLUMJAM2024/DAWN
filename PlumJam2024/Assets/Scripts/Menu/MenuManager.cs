using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MenuManager : MonoBehaviour // ¸Þ´º °ü¸® ½Ì±ÛÅæ Å¬·¡½º
{
    public Dictionary<string, MenuSO> menus = new Dictionary<string, MenuSO>();
    public static MenuManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
