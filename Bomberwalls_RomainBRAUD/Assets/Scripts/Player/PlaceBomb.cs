using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceBomb : MonoBehaviour
{
    public void OnPlace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (PlayerItems.Instance.PlayerGotABomb == true)
            {
                BombSpawn.Instance.PlayerSpawnBomb(gameObject.transform);
            }
        }
    }
}
