using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EmojiSO")]
public class EmojiSO : ScriptableObject
{
    [SerializeField] private Sprite EmojiSrite;

    public virtual Sprite GetSprite()
    {
        return EmojiSrite;
    }
}
