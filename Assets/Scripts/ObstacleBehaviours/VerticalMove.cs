
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Vitesse de déplacement de l'objet
    [SerializeField] private float minY = 0f; // Position minimale en Y
    [SerializeField] private float maxY = 5f; // Position maximale en Y
    [SerializeField] private float pauseTime = 1f; // Temps de pause en secondes
    [SerializeField] private bool startFromTop = true; // Si vrai, l'objet commencera son mouvement depuis le haut

    private int direction = 1; // Direction du mouvement (1 pour descendre, -1 pour monter)
    private bool isPaused = false; // Indique si l'objet est en pause

    private void Start()
    {
        if (!startFromTop)
            direction = -1; // Si on ne commence pas du haut, on va vers le bas
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Calcul du déplacement en fonction de la direction et de la vitesse
            float movement = direction * moveSpeed * Time.deltaTime;
            // Modification de la position en Y de l'objet
            transform.Translate(0f, movement, 0f);

            // Si l'objet atteint la position minimale ou maximale, on inverse la direction
            if (transform.position.y <= minY)
            {
                direction = 1;
                StartCoroutine(PauseCoroutine());
            }
            else if (transform.position.y >= maxY)
            {
                direction = -1;
            }
        }
    }

    IEnumerator PauseCoroutine()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseTime);
        isPaused = false;
    }
}