using UnityEngine.InputSystem;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.UIElements;

public class PlayerControlleriI : MonoBehaviour
{
    //movimiento general//
    private Rigidbody playerRb;
    private float movementX;
    private float movementY;
    public float speed;

    //subir escaleras
    public float stepHeight = 0.5f; //altura maxima escalones
    public float stepSmooth = 0.1f;
    public float maxDistance = 0.5f;
    public GameObject stepRayHigher;
    public GameObject stepRayLower;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        playerRb.AddForce(movement * speed);

        //si el movimiento no es cero, actualiza la rotacion del jugador
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            playerRb.rotation = Quaternion.Slerp(playerRb.rotation, targetRotation, Time.fixedDeltaTime * speed);
        }
        StepClimb(); //llamamos todo el rato a la funcion para subir escaleras
    }

    private void StepClimb() //para subir escaleras
    {
        RaycastHit lowerHit;
        RaycastHit higherHit;
        Ray higherRay = new Ray(stepRayHigher.transform.position, transform.forward);
        Ray lowerRay = new Ray(stepRayLower.transform.position, transform.forward);

        Debug.DrawRay(higherRay.origin, higherRay.direction * maxDistance, Color.red);
        Debug.DrawRay(lowerRay.origin, lowerRay.direction * maxDistance, Color.blue);

        bool higherRayHit = Physics.Raycast(higherRay, out higherHit, maxDistance);
        bool lowerRayHit = Physics.Raycast(lowerRay, out lowerHit, maxDistance);

        if (lowerRayHit && !higherRayHit)
        {
            // Elevar solo si el hit del rayo inferior está dentro de un cierto umbral
            if (lowerHit.point.y - transform.position.y < stepHeight)
            {
                transform.Translate(0f, stepHeight, 0.0f);
            }
        }

        if (lowerRayHit)
        {
            Debug.Log("Lower hit detected");
        }
        else if (higherRayHit)
        {
            Debug.Log("Higher hit detected");
        }
    }

}
