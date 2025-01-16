using UnityEngine;

public class CameraControlleriI : MonoBehaviour
{
    public GameObject player; //una variable que vinculara al player a la camara
    private Vector3 offset; //variable para la diferencia de posicion
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
