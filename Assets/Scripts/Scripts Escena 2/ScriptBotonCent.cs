using System.Collections;
using UnityEngine;

public class ScriptBotonCent : MonoBehaviour
{
    public ScriptsLeds scriptsLeds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scriptsLeds = GameObject.Find("Gestor de colores").GetComponent<ScriptsLeds>();
        scriptsLeds.isPressedCentb = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !scriptsLeds.isPressedCentb)
        {
            scriptsLeds.BotonCentPulsado();
            Debug.Log("PrimerPasoCent cumplido");
            scriptsLeds.isPressedCentb = true;
            StartCoroutine(ResetIsPressedCentb());

        }
    }

    private IEnumerator ResetIsPressedCentb()
    {
        yield return new WaitForSeconds(1f);
        scriptsLeds.isPressedCentb = false;
        Debug.Log("isPressedCentb reseteado");
    }

}



//Alonso canales(smartoclub) hizo practica en iguanabee