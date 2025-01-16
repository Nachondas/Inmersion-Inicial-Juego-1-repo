using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f; // Change gravity to a negative value
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform camaraFPS; // Referencia a la cámara en primera persona

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded; // Use CharacterController.isGrounded

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Movimiento basado en la dirección de la cámara
        Vector3 move = camaraFPS.right * x + camaraFPS.forward * y;
        move.y = 0f; // Asegurarse de que el personaje no se mueva verticalmente

        controller.Move(move * speed * Time.deltaTime);

       /* if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
       */
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != transform.position && isGrounded)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        lastPosition = transform.position;
    }
}
