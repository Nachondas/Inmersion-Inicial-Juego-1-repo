using UnityEngine;

public class triggerwin : MonoBehaviour
{
    public AudioSource audioSource;
    public Rigidbody parlante1Rigidbody;
    public Rigidbody parlante0Rigidbody;
    public GameManagerIi gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        parlante1Rigidbody = GameObject.Find("Amplificador1").GetComponent<Rigidbody>();
        parlante0Rigidbody = GameObject.Find("Amplificador").GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerIi>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColliderCentral"))
        {
            parlante1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            parlante1Rigidbody.isKinematic = true; //esto es para que no clipee con el player
            audioSource.Play();
            gameManager.isParlante1Listo = true;
            gameManager.UpdatePuntuacion();
        }

        if (other.gameObject.CompareTag("ColliderCentral2"))
        {
            parlante0Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            parlante0Rigidbody.isKinematic = true;
            audioSource.Play();
            gameManager.isParlante0Listo = true;
            gameManager.UpdatePuntuacion();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
