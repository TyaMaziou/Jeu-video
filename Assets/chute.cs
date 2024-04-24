
using System.Collections;
using UnityEngine;

public class StalactiteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject stalactitePrefab; // Préfabriqué de la stalactite à instancier
    [SerializeField] private float spawnInterval = 2f; // Intervalle entre chaque apparition de stalactite
    [SerializeField] private float fallSpeed = 5f; // Vitesse de chute de la stalactite
    [SerializeField] private float disappearY = 0f; // Position Y où la stalactite disparaît
    [SerializeField] private float rotateDelay = 1f; // Délai avant rotation (en secondes)

    private bool isRotating = false; // Indique si une stalactite est en train de pivoter

    private void Start()
    {
        StartCoroutine(SpawnStalactites());
    }

    private IEnumerator SpawnStalactites()
    {
        while (true)
        {
            // Instancier une nouvelle stalactite
            GameObject newStalactite = Instantiate(stalactitePrefab, transform.position, Quaternion.identity);

            // Attendre avant d'instancier la prochaine stalactite
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

public class StalactiteFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f; // Vitesse de chute de la stalactite
    [SerializeField] private float disappearY = 0f; // Position Y où la stalactite disparaît
    [SerializeField] private float rotateDelay = 1f; // Délai avant rotation (en secondes)

    private bool isFalling = false; // Indique si la stalactite est en train de tomber
    private bool isRotating = false; // Indique si la stalactite est en train de pivoter

    private void Update()
    {
        if (!isFalling)
        {
            StartCoroutine(FallCoroutine());
        }

        if (isRotating)
        {
            // Rotation de 90 degrés autour de l'axe Z
            transform.Rotate(0f, 0f, 90f * Time.deltaTime);
        }
    }

    private IEnumerator FallCoroutine()
    {
        isFalling = true;
        while (transform.position.y > disappearY)
        {
            // Déplacement de la stalactite vers le bas
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            yield return null;
        }

        // Stalactite atteint la position Y de disparition, la désactiver
        gameObject.SetActive(false);

        yield return new WaitForSeconds(rotateDelay);

        // Commencer la rotation
        isRotating = true;
    }
}
