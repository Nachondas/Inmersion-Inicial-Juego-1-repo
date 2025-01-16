using UnityEngine;

public class Fader : MonoBehaviour
{
    public float fadeSpeed;
    public float fadeAmount;
    float originalOpacity;
    public Material Mat;
    public bool DoFade = false;
    void Start()
    {
        Mat = GetComponent<Renderer>().material;
        originalOpacity = Mat.color.a;
        
    }

    void Update()
    {
        if (DoFade)
        {
            FadeNow();
        }
        else
        {
            ResetFade();
        }
    }

    void FadeNow()
    {
        Debug.Log("fade activado");
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }

    private void ResetFade()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;

        
    }
}
