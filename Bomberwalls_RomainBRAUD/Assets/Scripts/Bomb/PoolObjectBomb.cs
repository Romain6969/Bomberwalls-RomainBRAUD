using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectBomb : MonoBehaviour
{
    public static PoolObjectBomb instance { get; private set; }

    private List<GameObject> _pooledObjects = new List<GameObject>();
    private int _amount = 6;

    [SerializeField] private GameObject _bomb;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _amount; i++)
        {
            GameObject obj = Instantiate(_bomb);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int b = 0; b < _pooledObjects.Count; b++)
        {
            if (!_pooledObjects[b].activeInHierarchy)
            {
                return _pooledObjects[b];
            }
        }
        return null;
    }
}
