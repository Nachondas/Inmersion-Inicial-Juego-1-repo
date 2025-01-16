using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Textofinal : MonoBehaviour
{
    public GameObject esto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Ending());
        esto = GameObject.Find("FondoNegro");
        esto.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        
    }

    IEnumerator Ending()
    {
        Debug.Log("comenzo la corutina");
        yield return new WaitForSeconds(9);
        Debug.Log("segunda parte de la corutina");
        esto.SetActive(true);
    }

}
