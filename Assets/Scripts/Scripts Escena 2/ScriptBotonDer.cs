using System.Collections;
using UnityEngine;

public class ScriptBotonDer : MonoBehaviour
{
    public ScriptsLeds scriptLeds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scriptLeds = GameObject.Find("Gestor de colores").GetComponent<ScriptsLeds>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !scriptLeds.isPressedDerb)
        {
            scriptLeds.BotonDerPulsado();
            Debug.Log("DerPrimer paso listo");
            scriptLeds.isPressedDerb = true;
            StartCoroutine(ResetIsPressedDerb());
        }
    }

    IEnumerator ResetIsPressedDerb()
    {
        yield return new WaitForSeconds(1f);
        scriptLeds.isPressedDerb = false;
        Debug.Log("isPressedB reseteado");

    }
}
