using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S2Portal : MonoBehaviour
{
    //Comportamiento del portal
    public float velocidadPortal;
    public float velocidadPortalX;
    public Vector3 escalaFinalPortalX;
    public Vector3 escalaFinalPortal;
    public AudioSource sonidoPortal;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator S2PortalAbre()
    {
        Debug.Log("corutina portal Iniciada");
        while (Vector3.Distance(transform.localScale, escalaFinalPortalX) > 0.01f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, escalaFinalPortalX, velocidadPortalX * Time.deltaTime);
            yield return null;
        }
        while (Vector3.Distance(transform.localScale, escalaFinalPortal) > 0.01f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, escalaFinalPortal, velocidadPortal * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Escena2");
        }
    }
}
