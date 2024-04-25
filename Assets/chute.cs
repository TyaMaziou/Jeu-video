using UnityEngine;

public class FallingStalactite : MonoBehaviour
{
    [SerializeField] private float initialDelay = 0f;
    // Position initiale de la stalactite
    public Vector2 initialPosition = new Vector2(0f, 10f);

    // Position finale de la stalactite
    public Vector2 finalPosition = new Vector2(0f, 0f);

    // Vitesse de chute de la stalactite
    public float fallSpeed = 5f;

    //Vitesse de repop
    public float fallPause = 2f;

    // Bool�en pour v�rifier si la stalactite est en train de tomber ou de remonter
    private bool isFalling = true;
    private float timerFallPause = 0;
    private float delayTimer = 0;

    void Start()
    {
        // Positionner la stalactite � sa position initiale au d�but
        transform.position = initialPosition;
        delayTimer = initialDelay;
    }

    void Update()
    {
        // Si la stalactite est en train de tomber
        if (isFalling)
        {
            // Si le d�lai initial n'a pas encore expir�
            if (delayTimer > 0)
            {
                delayTimer -= Time.deltaTime;
                // Ne rien faire tant que le d�lai n'a pas expir�
                return;
            }
            
            // Calculer la direction vers la position finale ou initiale en fonction de l'�tat actuel
            Vector2 direction = isFalling ? (finalPosition - (Vector2)transform.position).normalized : (initialPosition - (Vector2)transform.position).normalized;

            // D�placer la stalactite vers sa position finale ou initiale � une vitesse constante
            transform.Translate(direction * fallSpeed * Time.deltaTime);

            // V�rifier si la distance restante est inf�rieure � la distance de d�placement par frame
            if ((isFalling && Vector2.Distance(transform.position, finalPosition) < fallSpeed * Time.deltaTime) ||
                (!isFalling && Vector2.Distance(transform.position, initialPosition) < fallSpeed * Time.deltaTime))
            {
                // La stalactite a atteint sa position finale ou initiale, inverser la direction
                transform.position = isFalling ? finalPosition : initialPosition;
                isFalling = !isFalling;
                timerFallPause = fallPause;
            }
        } 
        // Si la stalactite est en train de remonter
        else if (timerFallPause > 0)
        {
            // R�duire le temps de pause
            timerFallPause -= Time.deltaTime;

            // Si le temps de pause est �coul�
            if (timerFallPause <= 0)
            {
                // R�initialiser la position et passer en mode de chute
                timerFallPause = 0;
                transform.position = initialPosition;
                isFalling = true;
                delayTimer = initialDelay; // R�initialiser le d�lai pour le prochain cycle
            }
        }
    }
}
