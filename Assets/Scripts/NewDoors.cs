using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoors : MonoBehaviour
{
    public bool keepAnimatorStateOnDisable = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
