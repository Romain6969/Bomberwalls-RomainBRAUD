using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemBombSpawn : MonoBehaviour
{
    public static ItemBombSpawn Instance;
    private List<Nodes> nodes = new List<Nodes>();
    public int RandomNode;

    private void Awake()
    {
        Instance = this;
        foreach (Nodes n in FindObjectsOfType<Nodes>())
        {
            nodes.Add(n);
        }
    }

    public void SpawnItem()
    {
        GameObject item = PoolObjectItems.instance.GetPooledObject();
        item.transform.position = nodes[Random.Range(0, nodes.Count)].transform.position;
        item.SetActive(true);
    }
}
