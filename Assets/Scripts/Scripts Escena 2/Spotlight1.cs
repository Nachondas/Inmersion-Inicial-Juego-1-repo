using UnityEngine;

public class Spotlight1 : MonoBehaviour
{
    public Light luz;
    private AudioSource audioSource;
    private bool isPrendida;
    void Start()
    {
        luz = GetComponent<Light>();
        luz.enabled = false;
        audioSource = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPrendida)
        {
            audioSource.Play();
            luz.enabled = true;
            isPrendida = true;

        }


        
    }

}
