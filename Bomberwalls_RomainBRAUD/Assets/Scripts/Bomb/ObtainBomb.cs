using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainBomb : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerItems.Instance.PlayerGotABomb == true)
            {
                PlayerItems.Instance.PlayerGotABomb = true;
                gameObject.SetActive(false);
            }
        }
        if (collision.tag == "AI")
        {
            if (!PlayerItems.Instance.AIGotABomb == true)
            {
                PlayerItems.Instance.AIGotABomb = true;
                gameObject.SetActive(false);
            }
        }
    }
}
