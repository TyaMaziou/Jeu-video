using UnityEngine;
using System.Collections;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Vitesse de déplacement de l'objet
    [SerializeField] private float minX = 0f; // Position minimale en X
    [SerializeField] private float maxX = 5f; // Position maximale en X
    [SerializeField] private float pauseTime = 1f; // Temps de pause en secondes
    [SerializeField] private bool startFromRight = true; // Si vrai, l'objet commencera son mouvement depuis la droite

    private int direction = 1; // Direction du mouvement (1 pour aller vers la droite, -1 pour aller vers la gauche)
    private bool isPaused = false; // Indique si l'objet est en pause

    private void Start()
    {
        Debut(); // Appel de la méthode Debut() au début
    }

    private void Update()
    {
        Changement(); // Appel de la méthode Changement() à chaque mise à jour
    }

    private void Debut()
    {
        if (!startFromRight)
            direction = -1; // Si on ne commence pas de la droite, on va vers la gauche

        // Positionner l'objet à sa position initiale
        float initialX = startFromRight ? maxX : minX;
        transform.position = new Vector2(initialX, transform.position.y);
    }

    private void Changement()
    {
        if (!isPaused)
        {
            // Calcul du déplacement en fonction de la direction et de la vitesse
            float movement = direction * moveSpeed * Time.deltaTime;
            // Modification de la position en X de l'objet
            transform.Translate(movement, 0f, 0f);

            // Si l'objet atteint la position minimale ou maximale, on inverse la direction
            if (transform.position.x <= minX)
            {
                direction = 1;
                StartCoroutine(PauseCoroutine());
            }
            else if (transform.position.x >= maxX)
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
