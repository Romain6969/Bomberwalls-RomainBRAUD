using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarManager : MonoBehaviour
{
    public static AStarManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Nodes> GeneratePath(Nodes start, Nodes end)
    {
        List<Nodes> ActiveList = new List<Nodes>();

        foreach(Nodes n in FindObjectsOfType<Nodes>())
        {
            n.GScore = float.MaxValue;
        }
        

        start.GScore = 0;
        start.HScore = Vector2.Distance(start.transform.position, end.transform.position);
        ActiveList.Add(start);

        while (ActiveList.Count > 0)
        {
            int lowestF = default;

            for (int i = 1; i < ActiveList.Count; i++)
            {
                if (ActiveList[i].Fscore() < ActiveList[lowestF].Fscore())
                {
                    lowestF = i;
                }
            }

            Nodes currentNode = ActiveList[lowestF];
            ActiveList.Remove(currentNode);

            if (currentNode == end) 
            {
                List<Nodes> path = new List<Nodes>();

                path.Insert(0, end);

                while (currentNode != start)
                {
                    currentNode = currentNode.CameFrom;
                    path.Add(currentNode);
                }

                path.Reverse();
                return path;
            }

            foreach (Nodes connectNode in currentNode.Links)
            {

                float heldGScore = currentNode.GScore + Vector2.Distance(currentNode.transform.position, connectNode.transform.position);

                if (heldGScore < connectNode.GScore)
                {
                    connectNode.CameFrom = currentNode;
                    connectNode.GScore = heldGScore;
                    connectNode.HScore = Vector2.Distance(connectNode.transform.position, end.transform.position);

                    if (!ActiveList.Contains(connectNode))
                    {
                        ActiveList.Add(connectNode);
                    }
                }
            }
        }
        return null;
    }
}
