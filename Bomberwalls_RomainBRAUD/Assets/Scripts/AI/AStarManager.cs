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
    //La fonction qui prent en compte un node comme d�but et un node comme fin, sert � g�n�r� le chemin que l'IA aurat besoin pour arriver l� o� il est demander
    {
        List<Nodes> ActiveList = new List<Nodes>(); //On cr�er une liste qui servira de chemin pour l'IA

        foreach(Nodes n in FindObjectsOfType<Nodes>())
        {
            n.GScore = float.MaxValue; //Il faut que au moins dans chaque GScore il y est une valeur et pas rien.
        }
        

        start.GScore = 0;
        start.HScore = Vector2.Distance(start.transform.position, end.transform.position); //On donne la distance entre le d�but et l'arriver
        ActiveList.Add(start); //On rajoute le premier node du chemin dans la liste

        while (ActiveList.Count > 0) //Une boucle qui ne se termine pas tant que le code n'a pas renvoyer le chemin pour l'IA
        {
            int lowestF = default;

            for (int i = 1; i < ActiveList.Count; i++) //Pour savoir lequelle des nodes du chemin sont le plus court � l'arriver.
            {
                if (ActiveList[i].Fscore() < ActiveList[lowestF].Fscore())
                {
                    lowestF = i;
                }
            }

            Nodes currentNode = ActiveList[lowestF];
            ActiveList.Remove(currentNode);

            if (currentNode == end) //Si le code � r�ussie � faire un chemin jusqu'� l'arriver
            {
                List<Nodes> path = new List<Nodes>(); //On cr�er une liste qui sera le chemin de l'IA 

                path.Insert(0, end);

                while (currentNode != start) //On fait revenir jusqu'au d�but pour donner le chemin
                {
                    currentNode = currentNode.CameFrom;
                    path.Add(currentNode);
                }

                path.Reverse();
                return path; //On renvoi le chemin pour l'IA
            }

            foreach (Nodes connectNode in currentNode.Links) //Sinon on rajoute le node le plus court de l'arriver pour le chemin et on pr�pare pour la prochaine boucle
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
