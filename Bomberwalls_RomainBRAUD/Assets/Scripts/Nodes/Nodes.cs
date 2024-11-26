using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Nodes CameFrom;
    public List<Nodes> Links;

    public float GScore;
    public float HScore;

    public float Fscore()
    {
        return GScore + HScore;
    }

    private RaycastHit2D _hit;

    private void Awake()
    {
        _hit = Physics2D.Raycast(transform.position, Vector2.up, 1f);
        AddList();
        _hit = Physics2D.Raycast(transform.position, Vector2.left, 1f);
        AddList();
        _hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        AddList();
        _hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        AddList();
    }

    public void AddList()
    {
        if (_hit != _hit.collider.GetComponent<Nodes>()) return;

        Links.Add(_hit.collider.GetComponent<Nodes>());
        //Pour que si il détecte rien il ne renvoie pas une erreur
        _hit.collider.GetComponent<AStarManager>();
    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            PlayerItems.Instance.Items.Add(GetComponent<Nodes>());
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            PlayerItems.Instance.Items.Remove(GetComponent<Nodes>());
        }
    }
    */
}
