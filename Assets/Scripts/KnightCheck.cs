using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCheck : MonoBehaviour
{
    public GameObject knight;
    public GameObject jesterAI;
    public GameObject queenAI;
    public GameObject kingAI;
    public GameObject kingPos2;
    public GameObject kingPos1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jesterAI.GetComponent<Jester>().currentPos == 3 && knight.GetComponent<Knight>().currentPos == 1)
        {
            jesterAI.GetComponent<Jester>().knightOverride = true;
            jesterAI.GetComponent<Jester>().Movement();
        }
        else if (queenAI.GetComponent<Queen>().currentPos == 4 && knight.GetComponent<Knight>().currentPos == 2)
        {
            queenAI.GetComponent<Queen>().knightOverride = true;
            queenAI.GetComponent<Queen>().Movement();

        }
        else if ((kingAI.GetComponent<King>().currentPos == 3 || kingAI.GetComponent<King>().currentPos == 4) && knight.GetComponent<Knight>().currentPos == 3)
        {
            if (kingPos2.activeSelf)
            {
                kingAI.GetComponent<King>().knightOverride = true;
                kingAI.GetComponent<King>().Movement();
                kingAI.GetComponent<King>().knightOverride = true;
                kingAI.GetComponent<King>().Movement();
            }
            else if (kingPos1.activeSelf)
            {
                kingAI.GetComponent<King>().knightOverride = true;
                kingAI.GetComponent<King>().Movement();
            }

        }
    }
}
