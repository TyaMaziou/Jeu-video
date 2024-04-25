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

    // Booléen pour vérifier si la stalactite est en train de tomber ou de remonter
    private bool isFalling = true;
    private float timerFallPause = 0;
    private float delayTimer = 0;

    void Start()
    {
        // Positionner la stalactite à sa position initiale au début
        transform.position = initialPosition;
        delayTimer = initialDelay;
    }

    void Update()
    {
        // Si la stalactite est en train de tomber
        if (isFalling)
        {
            // Si le délai initial n'a pas encore expiré
            if (delayTimer > 0)
            {
                delayTimer -= Time.deltaTime;
                // Ne rien faire tant que le délai n'a pas expiré
                return;
            }
            
            // Calculer la direction vers la position finale ou initiale en fonction de l'état actuel
            Vector2 direction = isFalling ? (finalPosition - (Vector2)transform.position).normalized : (initialPosition - (Vector2)transform.position).normalized;

            // Déplacer la stalactite vers sa position finale ou initiale à une vitesse constante
            transform.Translate(direction * fallSpeed * Time.deltaTime);

            // Vérifier si la distance restante est inférieure à la distance de déplacement par frame
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
            // Réduire le temps de pause
            timerFallPause -= Time.deltaTime;

            // Si le temps de pause est écoulé
            if (timerFallPause <= 0)
            {
                // Réinitialiser la position et passer en mode de chute
                timerFallPause = 0;
                transform.position = initialPosition;
                isFalling = true;
                delayTimer = initialDelay; // Réinitialiser le délai pour le prochain cycle
            }
        }
    }
}
