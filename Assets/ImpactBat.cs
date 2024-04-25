using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatImpact : MonoBehaviour // Renommer la classe en BatImpact
{
    // Position d'origine de la chauve-souris
    private Vector2 batStartPosition;

    // Fonction appel�e au d�marrage de la sc�ne
    void Start()
    {
        // Enregistrer la position d'origine de la chauve-souris
        batStartPosition = transform.position;
    }

    //Si un objet rentre en collision avec l'obstacle
    void OnTriggerEnter2D(Collider2D col)
    {
        // Si l'obstacle entre en collision avec le joueur (objet avec le tag "Player")
        if (col.gameObject.tag == "Player")
        {
            // R�initialiser la position de la chauve-souris � sa position d'origine
            transform.position = batStartPosition;
        }
    }
}
