using UnityEngine;

public class MusicaEnding : MonoBehaviour
{
    float startTime = 37f;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = startTime;
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
