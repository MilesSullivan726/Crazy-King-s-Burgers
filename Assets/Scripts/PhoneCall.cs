using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public GameObject muteButton;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartCall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteCall()
    {
        audioSource.Stop();
        muteButton.SetActive(false);
    }

    IEnumerator StartCall()
    {
        yield return new WaitForSeconds(3);
        audioSource.Play();
        muteButton.SetActive(true);

    }
}
