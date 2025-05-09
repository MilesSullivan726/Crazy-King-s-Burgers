using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeAmbiance : MonoBehaviour
{

    public GameObject office;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (office.activeSelf)
        {
            audioSource.volume = 0.2f;
        }
        else
        {
            audioSource.volume = 0.1f;
        }
    }
}
