using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPV : MonoBehaviour
{
    public static WallPV Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int PV = 10;
}