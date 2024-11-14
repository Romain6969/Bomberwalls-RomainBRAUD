using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public static PlayerItems Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool PlayerGotABomb { get; set; }
    public bool AIGotABomb { get; set; }
    public List<Nodes> Items = new List<Nodes>();
}
