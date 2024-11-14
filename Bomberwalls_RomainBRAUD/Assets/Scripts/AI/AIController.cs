using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //The node at wich the AI start
    public Nodes CurrentNode;
    public List<Nodes> path = new List<Nodes>();
    private List<Nodes> _nodes = new List<Nodes>();
    private bool StopInfinite = false;
    private Nodes _wichDirection;
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

    public Nodes WichTarget()
    {
        //Nodes[] nodes = FindObjectsOfType<Nodes>();
        if (PlayerItems.Instance.AIGotABomb == true)
        {
            if (gameObject.transform.position == BreakableWall.transform.position)
            {
                BombSpawn.Instance.AISpawnBomb(gameObject.transform);
            }

            return _wichDirection = BreakableWall;
        }
        
        if (PlayerItems.Instance.AIGotABomb == false)
        {
            /*
            if (PlayerItems.Instance.Items.Count > 0)
            {
                return _wichDirection = PlayerItems.Instance.Items[0];
            }
            */

            //Cette méthode ne marche pas alors que ca ne devrai pas faire une boucle infinie
            
            if (StopInfinite == false)
            {
                for (int i = 0; i < _nodes.Count; i++)
                {
                    if (_nodes[i] == PlayerItems.Instance.Items[0])
                    {
                        StopInfinite = true;
                        return _nodes[i];
                    }
                }
            }
            
        }
        return _wichDirection;
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
        else
        {
            //Nodes[] nodes = FindObjectsOfType<Nodes>();
            while (path == null || path.Count == 0)
            {
                path = AStarManager.Instance.GeneratePath(CurrentNode, WichTarget());
                // pour random où il doit aller il faut mettre nodes[Random.Range(0, nodes.Length)], si le Wichtarget ne marche pas.
            }
        }
    }
}
