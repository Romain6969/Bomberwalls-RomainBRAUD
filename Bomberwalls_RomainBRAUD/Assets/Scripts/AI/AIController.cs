using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //La node où l'IA commence
    public Nodes CurrentNode;
    public List<Nodes> path = new List<Nodes>();
    private List<Nodes> _nodes = new List<Nodes>();
    public Nodes BreakableWall;

    private void Awake()
    {
        foreach(Nodes n in FindObjectsOfType<Nodes>())
        {
            _nodes.Add(n);
        }
    }

    private void Update()
    {
        CreatePath();
    }

    public void CreatePath()
    {
        if (path.Count > 0)
        {
            int x = 0;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(path[x].transform.position.x, path[x].transform.position.y, 0), 3 * Time.deltaTime);

            if (Vector2.Distance(transform.position, path[x].transform.position) < 0.1f)
            {
                CurrentNode = path[x];
                path.RemoveAt(x);
            }
        }

        else if (PlayerItems.Instance.AIGotABomb == true)
        {
            path = AStarManager.Instance.GeneratePath(CurrentNode, BreakableWall);
            if (transform.position == path[0].transform.position)
            {
                BombSpawn.Instance.AISpawnBomb(gameObject.transform);
            }
        }
        else if (FindAnyObjectByType<ObtainBomb>() != null)
        {
            ObtainBomb[] obtainBomb = FindObjectsOfType<ObtainBomb>();
            while (path == null || path.Count == 0)
            {
                path = AStarManager.Instance.GeneratePath(CurrentNode, obtainBomb[Random.Range(0, obtainBomb.Length)].Node);
            }
        }
        else
        {
            Nodes[] nodes = FindObjectsOfType<Nodes>();
            while (path == null || path.Count == 0)
            {
                path = AStarManager.Instance.GeneratePath(CurrentNode, nodes[Random.Range(0, nodes.Length)]);
            }
        }
    }
}
