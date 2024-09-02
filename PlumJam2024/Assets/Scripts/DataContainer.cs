using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    public static DataContainer instance;

    [Header("Sprites")]
    public Sprite orderWaiting;
    public Sprite enjoying;
    public Sprite angryLeaving;
    public Sprite cheesecake;
    public Sprite chocolatecake;
    public Sprite cookiecheesecake;
    public Sprite croissant;
    public Sprite pancake;
    public Sprite chocolatepancake;
    public Sprite tirimasu;


    private void Awake() {
        instance = this;
    }
}
