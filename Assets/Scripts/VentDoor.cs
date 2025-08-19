using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentDoor : MonoBehaviour
{
    public GameObject ventDoor;
    public AudioClip closeSFX;
    public AudioClip openSFX;
    public bool isClosed = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = ventDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(closeSFX);
        isClosed = true;
    }

    public void OnMouseDrag()
    {
        animator.SetBool("closeVent", true);
        isClosed = true;
    }

    private void OnMouseUp()
    {
        animator.SetBool("closeVent", false);
        gameObject.GetComponent<AudioSource>().PlayOneShot(openSFX);
        isClosed = false;
    }
}
