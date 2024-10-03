using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public Dictionary<string, MenuSO> menus = new Dictionary<string, MenuSO>();
    public Dictionary<string, EmojiSO> emojis = new Dictionary<string, EmojiSO>();
    
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

    private void Start()
    {
        LoadMenus();
        LoadEmojis();
    }

    private void LoadMenus()
    {
        MenuSO[] loadDatas = Resources.LoadAll<MenuSO>("Menus");

        foreach (MenuSO menu in loadDatas)
        {
            menus.Add(menu.name, menu);
            Debug.Log(menu.name);
        }
    }

    private void LoadEmojis()
    {
        EmojiSO[] loadDatas = Resources.LoadAll<EmojiSO>("Emojis");

        foreach (EmojiSO emoji in loadDatas)
        {
            emojis.Add(emoji.name, emoji);
            Debug.Log(emoji.name);
        }
    }

    public MenuSO GetRandomMenu()
    {
        if (menus.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, menus.Count);
            string randomKey = new List<string>(menus.Keys)[randomIndex];
            return menus[randomKey];
        }
        Debug.LogError("메뉴 리스트가 0개");
        return null;
    }
}
