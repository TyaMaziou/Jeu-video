using UnityEngine;

public class TransparentFlashing : MonoBehaviour
{
    [SerializeField] private float initialDelay = 0f; // A partir de combien de secondes le clignotement démarre
    [SerializeField] private float goToOpaque = 1f; // Combien de temps dure la transition de transparent à opaque
    [SerializeField] private float opaque = 1f; // Combien de temps il reste opaque
    [SerializeField] private float goToTransparent = 1f; // Combien de temps dure la transition d'opaque à transparent
    [SerializeField] private float transparent = 1f; // Combien de temps il reste transparent
    [SerializeField] private float opacityLevel = 1f; // Niveau d'opacité personnalisé
    [SerializeField] private bool startOpaque = true; // Est-ce qu'il commence opaque ?

    private SpriteRenderer _sprite;
    private int _step = 0; // 0 opaque, 1 goToTransparent, 2 transparent, 3 goToOpaque
    private float _timer = 0;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>(); // On récupère le sprite
        _timer = opaque; // On commence le timer à la valeur qu'il dure opaque
        if (!startOpaque)
        { // S'il ne commence pas opaque
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 0); // On met le sprite en transparent
            _step = 2; // on est à l'étape 2 (transparent)
            _timer = transparent; // On commence le timer à la valeur qu'il dure transparent
        }
    }

    void FixedUpdate()
    {
        // S'il y a un délai avant qu'il commence à bouger
        if (initialDelay > 0)
        {
            initialDelay = Mathf.Max(0, initialDelay - Time.fixedDeltaTime);
        }
        // Sinon, si c'est le timer qui n'est pas fini
        else if (_timer > 0)
        {
            _timer = Mathf.Max(0, _timer - Time.fixedDeltaTime);
            if (_step == 1)
            { // Si on est sur l'étape 1, transition d'opaque à transparent
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, (_timer / goToTransparent) * opacityLevel);
            }
            else if (_step == 3)
            { // Si on est sur l'étape 3, transition de transparent à opaque
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, (1 - (_timer / goToOpaque)) * opacityLevel);
            }
        }
        // Si le timer est fini, passer à l'étape suivante
        else
        {
            _step = (_step + 1) % 4;
            _timer = returnTimeStep(); // Charger la prochaine valeur dans le timer
        }
    }

    // Fonction qui retourne quelle est la valeur du timer à charger selon l'étape en cours
    private float returnTimeStep()
    {
        if (_step == 0)
        {
            return opaque;
        }
        else if (_step == 1)
        {
            return goToTransparent;
        }
        else if (_step == 2)
        {
            return transparent;
        }
        else
        {
            return goToOpaque;
        }
    }
}
