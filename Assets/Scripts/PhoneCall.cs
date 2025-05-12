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
        StartCoroutine(HideMuteCallEnd());
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

    IEnumerator HideMuteCallEnd()
    {
        yield return new WaitForSeconds(156);
        muteButton.SetActive(false);
    }

    IEnumerator StartCall()
    {
        yield return new WaitForSeconds(3);
        audioSource.Play();
        muteButton.SetActive(true);

    }
}
