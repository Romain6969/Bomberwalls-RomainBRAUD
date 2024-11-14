using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLife : MonoBehaviour
{
    [SerializeField] private List<GameObject> _explosions = new List<GameObject>();

    private IEnumerator OnBecameVisible()
    {
        yield return new WaitForSeconds(4);

        for (int i = 0; i < _explosions.Count; i++)
        {
            _explosions[i].SetActive(true);
        }

        yield return new WaitForSeconds(1);

        ItemBombSpawn.Instance.SpawnItem();
        for (int i = 0; i < _explosions.Count; i++)
        {
            _explosions[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
