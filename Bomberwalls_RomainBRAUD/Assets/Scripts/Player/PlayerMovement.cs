using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRB2;

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    private void Update()
    {
        
    }

    //Pour comment ca marche pour les nodes : chaque nodes ont une même class qui donne les infos de leur positions et leur adjacent(voisins).
    //Il faut faire une liste avec des listes, il y aurat une liste active et une liste réservoire.
    //le script de l'IA regarde quelle est le node le plus courte de l'arriver et met met le node le plus court dans l'active,
    //l'autre sera dans le réservoir, puis il refait le calcul avec les nodes adjacent de celle de l'active et aussie de celui du réservoir.
    //le sript compte aussie le nombre de nodes que l'on à traversé pour savoir quelle est le chemin le plus court 
}
