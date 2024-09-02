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
    public Sprite bread;
    public Sprite cake;
    public Sprite coffee;

    private void Awake() {
        instance = this;
    }
}
