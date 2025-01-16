using System.Collections;
using UnityEngine;

public class ScriptBotonIzq : MonoBehaviour
{
    public ScriptsLeds scriptsLeds;
    void Start()
    {
        scriptsLeds = GameObject.Find("Gestor de colores").GetComponent<ScriptsLeds>();
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !scriptsLeds.isPressedIzqb)
        {
            scriptsLeds.BotonIzqPulsado();
            Debug.Log("primerpaso cumplido");
            scriptsLeds.isPressedIzqb = true;
            StartCoroutine(ResetIsPressedIzqb());

        }
    }
    private IEnumerator ResetIsPressedIzqb()
    {
        yield return new WaitForSeconds(1f);
        scriptsLeds.isPressedIzqb = false;
        Debug.Log("isPressedIzqb reseteado");
    }

}
