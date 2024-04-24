
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; //Vitesse de l'objet, modifiable
    [SerializeField] private int xSens = 1; //Le sens de l'objet (1 si vers la droite, -1 si vers la gauche)
    [SerializeField] private Rigidbody2D rb; //Le rigidbody pour bouger l'obstacle
    private Vector2 movement;
    [SerializeField] private float delay = 0f;
    [SerializeField] private float pause = 0f;

    private float pauseTimer = 0f;

    //Au démarrage, défini la variable de mouvement
    void Start(){
        movement = new Vector2(xSens, 0);
    }

    //A chaque frame, on bouge l'objet via son rigidbody dans le mouvement défini * la vitesse de l'objet moveSpeed * Time.fixedDeltaTime le laps de temps écoulé en 1 frame
    void FixedUpdate() {
        if (delay > 0) 
        {
            delay = delay - Time.fixedDeltaTime; //regarde combien ça vaut et met la variable en bas
        } else if(pauseTimer > 0){
            pauseTimer = pauseTimer - Time.fixedDeltaTime;
        } else {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Si l'obstacle rentre en collision avec un mur, on inverse son mouvement horizontal pour qu'il aille dans le sens contraire
        if (col.gameObject.tag == "Wall") {
            movement.x = movement.x * -1;
            pauseTimer = pause;
        }
    }
}