using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptsLeds : MonoBehaviour
{
    //Color de Leds
    public Material rojo;
    public Material verde;
    private Renderer ledCent;
    private Renderer ledIzq;
    private Renderer ledDer;

    public bool isRojoLedIzq;
    public bool isRojoLedCent;
    public bool isRojoLedDer;


    //Botones
    public Animator animIzq;
    public Animator animCent;
    public Animator animDer;

    public bool isPressedIzqb;
    public bool isPressedCentb;
    public bool isPressedDerb;

    public AudioSource sonidoClickIzq;
    public AudioSource sonidoClickCent;
    public AudioSource sonidoClickDer;

    private bool isPortalAbierto;
    

    public S2Portal s2Portal;
    public GameObject s2PortalObject;


    //Debugger
    public TextMeshProUGUI textodebugger;
    public bool IzqOk;
    public bool CentOk;
    public bool DerOk;
    private bool isPortalAbreIniciado;



    void Start()
    {
        ledIzq = GameObject.Find("LED3").GetComponent<Renderer>();
        ledCent = GameObject.Find("LED1").GetComponent<Renderer>();
        ledDer = GameObject.Find("LED2").GetComponent<Renderer>();
        s2Portal = GameObject.Find("S2Portal").GetComponent<S2Portal>();
        s2PortalObject = GameObject.Find("S2Portal");

        s2PortalObject.SetActive(false);

        ledIzq.material = rojo;
        ledCent.material = rojo;
        ledDer.material = rojo;

        isRojoLedIzq = true;
        isRojoLedCent = true;
        isRojoLedDer = true;

        IzqOk = false;
        CentOk = true;
        DerOk = false;

        isPortalAbreIniciado = false;

        textodebugger.text = "IzqOk" + IzqOk + "CentOk" + CentOk + "DerOk" + DerOk;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("New Scene");
        }
        if (!isPortalAbierto)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                prueba();
            }
            textodebugger.text = "IzqOk" + IzqOk + "CentOk" + CentOk + "DerOk" + DerOk;
            ChecaCondicion();

        }


    }

    public void prueba()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("presionaste V");
            s2Portal.StartCoroutine("S2PortalAbre");
            
        }
    }

    public void BotonIzqPulsado()
    {
        if (!isPortalAbierto)
        {
           Debug.Log("BotonIzqPulsado");
           animIzq.SetTrigger("isPressedIzq");
           isPressedIzqb = true;
           sonidoClickIzq.Play();

            if (isRojoLedIzq)
            {
                ledIzq.material = verde;
            }
            else
            {
                ledIzq.material = rojo;
            }
            isRojoLedIzq = !isRojoLedIzq;
            IzqOk = !IzqOk;
            ChecaCondicion();
        }
        


        /*La línea isRojoled1 = !isRojoled1 invierte el estado de la variable:
        Si es true, se vuelve false.  Si es false, se vuelve true. */

    }

    public void BotonCentPulsado()
    {
        if (!isPortalAbierto)
        {
           Debug.Log("BotonCentPulsado");
           animCent.SetTrigger("isPressedCent");
           isPressedCentb = true;
           sonidoClickCent.Play();

           if (isRojoLedCent)
           {
               ledCent.material = verde;
           }
           else
           {
               ledCent.material = rojo;
           }
           isRojoLedCent = !isRojoLedCent;
           CentOk = !CentOk;
           ChecaCondicion();

        }

    }
    


    

    public void BotonDerPulsado()
    {
        if (!isPortalAbierto)
        {
            Debug.Log("BotonDerPulsado");
            animDer.SetTrigger("isPressedDer");
            isPressedDerb = true;
            sonidoClickDer.Play();

            if (isRojoLedDer)
            {
                ledDer.material = verde;
            }
            else
            {
                ledDer.material = rojo;
            }
            isRojoLedDer = !isRojoLedDer;
            DerOk = !DerOk;
            ChecaCondicion();
        }
    }
    private void ChecaCondicion()
    {
        if (IzqOk && CentOk && DerOk)
        {
            if (!isPortalAbreIniciado)
            {
                s2PortalObject.SetActive(true);
                isPortalAbreIniciado = true;
                isPortalAbierto = true;
                s2Portal.StartCoroutine("S2PortalAbre");

            }
        }
        else
        {
            isPortalAbreIniciado = false;
            isPortalAbierto = false;
        }
    }

}
