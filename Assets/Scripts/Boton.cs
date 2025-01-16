using System;
using UnityEngine;

public class Boton : MonoBehaviour
{
    private Animator animator;
    public bool musica = false;
    public AudioSource amplificador1;
    public AudioSource amplificador2;
    public AudioSource sonidoClick;
    private bool isPressedb = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        amplificador1 = GameObject.Find("Amplificador1").GetComponent<AudioSource>();
        amplificador2 = GameObject.Find("Amplificador").GetComponent<AudioSource>();
        sonidoClick = GetComponent<AudioSource>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !isPressedb)
        {
            Debug.Log("Boton activado");
            animator.SetTrigger("isPressed");
            DaleMusica();
            isPressedb = true;
            sonidoClick.Play();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("presionaste e");
        }
        
    }
    public void DaleMusica()
    {
        musica = true;
        amplificador1.Play();
        amplificador2.Play();
    }
}
