using UnityEngine;

public class BotonTarima : MonoBehaviour
{
    private Animator animator;
    public AudioSource clickTarima;
    public bool botonTIsPressedb = false;
    public GameManagerIi gameManagerIi;
    void Start()
    {
        animator = GetComponent<Animator>();
        clickTarima = GetComponent<AudioSource>();
        gameManagerIi = GameObject.Find("GameManager").GetComponent<GameManagerIi>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !botonTIsPressedb)
        {
            Debug.Log("boton tarima activado");
            animator.SetTrigger("isPressed");
            botonTIsPressedb = true;
            clickTarima.Play();

            gameManagerIi.StartCoroutine(gameManagerIi.Camara3Go());
        }
    }


    void Update()
    {
        
    }
}
