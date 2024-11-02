using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Nombre: Mario Alberto Rangel Márquez
Descripción: Prototype 2
Fecha: 02/11/2024
*/
public class MovementController : MonoBehaviour
{
    //Velocidad de los personajes
    public float movementSpeed = 3.0f;

    //Representa la ubicación del Player o Enemy
    Vector2 movement = new Vector2();

    //Referencia a Rigidbody2D
    Rigidbody2D rb2D;

    Animator animator; //Referencia a componente animator
    string animationState = "AnimationState"; //Variable en Animator

    //Enumeración de los estados
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateState();
    }



/*
 * Método que define la definición a ejecutar en base al movimiento realizado por el usuario.
 */
private void UpdateState() 
{
    if (movement.x > 0) { // ESTE
        animator.SetInteger(animationState, (int)CharStates.walkEast);
    }
    else if (movement.x < 0) { // OESTE
        animator.SetInteger(animationState, (int)CharStates.walkWest);
    }
    else if (movement.y > 0) { // NORTE
        animator.SetInteger(animationState, (int)CharStates.walkNorth);
    }
    else if (movement.y < 0) { // SUR
        animator.SetInteger(animationState, (int)CharStates.walkSouth);
    }
    else { // IDLE
        animator.SetInteger(animationState, (int)CharStates.idleSouth);
    }
}


/*

*/

private void FixedUpdate() {
    MoveCharacter(); // Método definido para ingresar la dirección
}

/*
 Nombre: Mario Alberto Rangel Márquez
 */
private void MoveCharacter() {
    // Captura los datos de entrada del usuario
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    // Conserva el rango de velocidad
    movement.Normalize();
    rb2D.velocity = movement * movementSpeed;
}



}
