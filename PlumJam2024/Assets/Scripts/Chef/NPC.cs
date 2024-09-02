using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, Iinteractable
{
    [SerializeField] private SpriteRenderer interactCheckSprite;
    protected Player player;

    private const float INTERACT_DISTANCE = 2f;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        _Update();
        if (Input.GetKeyDown(KeyCode.E) && IsInteract())
        {
            Interact();
        }

        if (interactCheckSprite.gameObject.activeSelf && !IsInteract())
        {
            interactCheckSprite.gameObject.SetActive(false);
        }
        else if (!interactCheckSprite.gameObject.activeSelf && IsInteract())
        {
            interactCheckSprite.gameObject.SetActive(true);
        }
    }

    public abstract void Interact();
    public abstract void _Update();
    protected bool IsInteract()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < INTERACT_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}