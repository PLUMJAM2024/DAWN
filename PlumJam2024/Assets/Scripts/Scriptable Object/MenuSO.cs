using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuSO : ScriptableObject
{
    [SerializeField] protected float cookingTime;
    [SerializeField] protected Sprite foodSprite;

    public virtual float GetCookingTime()
    {
        return cookingTime;
    }

    public virtual Sprite GetSprite()
    {
        return foodSprite;
    }
}
