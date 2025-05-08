using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthHall : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject office;
    public Sprite doorOpen;
    public Sprite doorClosed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (office.GetComponent<Office>().isDoorOpen == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
        }
    }
}
