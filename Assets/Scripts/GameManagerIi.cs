using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIi : MonoBehaviour
{
    public int puntuacion = 0;
    public float velocidadSubida;
    public GameObject escalera;
    public GameObject plataforma;
    public GameObject Tarima;
    public Boton botonScript;
    public GameObject amplificador1;
    public GameObject player;
    public GameObject player2;
    public AudioSource parlante1;
    public AudioSource parlante2;

    //cinemática
    public Vector3 posicionFinalEscalera;
    public Vector3 posicionFinalPlataforma;
    private bool llegamosAlaMeta = false;
    public GameObject camara1;
    public GameObject camara2;

    //Cinematica2
    public GameObject camara3;
    public Vector3 posicionFinalCamara3;
    public float velocidadDollyIn;
    public Transform portal;
    public float velocidadPortal;
    public float velocidadPortalX;
    public Vector3 escalaFinalPortalX;
    public Vector3 escalaFinalPortal;
    public AudioSource sonidoPortal;

    //tarima
    public Rigidbody tarima;
    public AudioSource sonidoTarima;


    public bool isParlante1Listo = false;
    public bool isParlante0Listo = false;

    

    void Start()
    {
        GameObject amplificador1 = GameObject.Find("Amplificador1");
        Transform botonATransform = amplificador1.transform.Find("BotonA");
        botonScript = botonATransform.GetComponent<Boton>();
        tarima = GameObject.Find("BaseTarima").GetComponent<Rigidbody>();
        tarima.isKinematic = true;
        sonidoTarima = GameObject.Find("BaseTarima").GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");
        player2.SetActive(false);
        
    }

    void Update()
    {
        CheckMusica();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(Camara3Go());
        }


    }
    public void UpdatePuntuacion()
    {
        if (isParlante1Listo || isParlante0Listo)
        {
            puntuacion++;
        }

        if(puntuacion >= 3 && !llegamosAlaMeta)//si la puntuacion es mayor que tres y aun no llegamos a la meta
        {
            if (botonScript.musica)
            {
             StartCoroutine(Elevense());
             StartCoroutine(CambiodeCamaras());
             llegamosAlaMeta = true;
            }
            

        }
    }

    public void CheckMusica()
    {
        if (puntuacion >= 3 && !llegamosAlaMeta && botonScript.musica)
        {
            StartCoroutine(Elevense());
            StartCoroutine(CambiodeCamaras());
            llegamosAlaMeta = true;
        }
    }



    IEnumerator Elevense()
    {
        StartCoroutine(MoverEscalera());
        yield return new WaitForSeconds(2);
        StartCoroutine(MoverPlataforma());

    }
    /* Elevense tenía el problema de que para recorrer del punto inicial al punto final del trayecto
 * era necesario que fuese llamado en cada frame. Update podía hacerlo, pero las camaras
 * se bugeaban al ser llamadas constantemente. Por eso Elevense se decidió cambiarlo a
 * un While el cual llama a la función hasta que se complete el recorrido*/
    IEnumerator MoverEscalera()
    {
        while (Vector3.Distance(escalera.transform.position, posicionFinalEscalera) > 0.01f)
        {
            escalera.transform.position = Vector3.MoveTowards(escalera.transform.position, posicionFinalEscalera, velocidadSubida * Time.deltaTime);
            yield return null;
            //subida escalera
        }
    }

    IEnumerator MoverPlataforma()
    {
        while (Vector3.Distance(plataforma.transform.position, posicionFinalPlataforma) > 0.01f)
        {
            plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, posicionFinalPlataforma, velocidadSubida * Time.deltaTime);
            yield return null;//subida plataforma
            
        }
        CaidaTarima();
    }
/* Al pasarlo a un While no se podía controlar el tiempo entre que empezaba a subir la escalera
 * y la plataforma, así que hubo que separarlo en 2 corutinas */

    void CaidaTarima()
    {
        sonidoTarima.time = 17f;
        tarima.isKinematic = false;
        sonidoTarima.Play();

        Invoke("StopAudio", 3f);

    }

    private void StopAudio()
    {
        sonidoTarima.Stop();
    }

    public IEnumerator Camara3Go()
    {
        parlante1.Stop();
        parlante2.Stop();
        camara3.SetActive(true);
        sonidoPortal.Play();
     
        StartCoroutine(PortalAbre());
        while (Vector3.Distance(camara3.transform.position, posicionFinalCamara3) > 0.01f)
        {
            camara3.transform.position = Vector3.MoveTowards(camara3.transform.position, posicionFinalCamara3, velocidadDollyIn * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        camara3.SetActive(false);
        player.SetActive(false);
        player2.SetActive(true);

    }

    public IEnumerator PortalAbre()
    {
        Debug.Log("PortalAbre iniciado");
        while (Vector3.Distance(portal.transform.localScale, escalaFinalPortalX) > 0.01f)
        {
            portal.transform.localScale = Vector3.MoveTowards(portal.transform.localScale, escalaFinalPortalX, velocidadPortalX * Time.deltaTime);
            yield return null;
        }
        while (Vector3.Distance(portal.transform.localScale, escalaFinalPortal) > 0.01f)
        {
            portal.transform.localScale = Vector3.MoveTowards(portal.transform.localScale, escalaFinalPortal, velocidadPortal * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CambiodeCamaras()
    {
        camara2.SetActive(true);
        yield return new WaitForSeconds(7);
        camara2.SetActive(false);

    }

}
