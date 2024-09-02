using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Queue<Enums.Menu> menuQueue = new Queue<Enums.Menu>(8);
    public Enums.Menu servingMenu;
    public bool isServing = false;
}