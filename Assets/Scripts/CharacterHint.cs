using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterHint : MonoBehaviour
{
    public GameObject hintSystem;
    public string characterName;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        hintSystem.SetActive(true);
        if (!hintSystem.GetComponent<HelpButton>().charOnScreen.Contains(characterName))
        {
            
            hintSystem.GetComponent<HelpButton>().charOnScreen.Add(characterName);
        } 
    }
}
