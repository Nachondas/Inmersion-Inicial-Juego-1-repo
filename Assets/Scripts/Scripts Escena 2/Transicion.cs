using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Transicion : MonoBehaviour
{
    public Image imagen;
    public float duracion = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeOut());
        
    }

    IEnumerator FadeOut()
    {
        float tiempoTranscurrido = 0f;
        Color colorInicial = imagen.color;
        Color colorFinal = new Color(colorInicial.r, colorInicial.g, colorInicial.b, 0);
        while (tiempoTranscurrido < duracion)
        {
            tiempoTranscurrido += Time.deltaTime;
            imagen.color = Color.Lerp(colorInicial, colorFinal, tiempoTranscurrido / duracion);
            yield return null;
        }
        imagen.color = colorFinal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
