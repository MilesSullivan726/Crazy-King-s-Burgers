using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSFX : MonoBehaviour
{

    public AudioClip[] officeSFXs;
    public AudioClip[] camSFXs;
    public GameObject office;
    private int sfxToPlay;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayAmbiance", 30, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAmbiance()
    {
        if (office.activeSelf) //player is in office
        {
            sfxToPlay = Random.Range(0, officeSFXs.Length);
            audioSource.PlayOneShot(officeSFXs[sfxToPlay]);
        }
        else
        {
            sfxToPlay = Random.Range(0, camSFXs.Length);
            audioSource.PlayOneShot(camSFXs[sfxToPlay]);
        }
    }
}
