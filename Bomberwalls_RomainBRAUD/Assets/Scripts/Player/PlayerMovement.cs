using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRB2;
    [SerializeField] private float _speed;
    private Vector2 _movement;

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        transform.Translate(_movement * _speed * Time.deltaTime);
    }

    //Pour comment ca marche pour les nodes : chaque nodes ont une même class qui donne les infos de leur positions et leur adjacent(voisins).
    //Il faut faire une liste avec des listes, il y aurat une liste active et une liste réservoire.
    //le script de l'IA regarde quelle est la node la plus courte de l'arriver et met la node la plus courte dans l'active,
    //l'autre sera dans le réservoir, puis il refait le calcul avec les nodes adjacent de celle de l'active et aussie de celui du réservoir.
    //le sript compte aussie le nombre de nodes que l'on à traversé pour savoir quelle est le chemin le plus court 
}
