using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFlash : MonoBehaviour
{
    public Sprite normal;
    public Sprite twisted;
    public float interval;
    public bool isKing = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("CallFunction", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CallFunction()
    {
        StartCoroutine(FlashSprite());
    }

    IEnumerator FlashSprite()
    {
        if(Random.Range(0,2) == 1 && !isKing)
        {
            spriteRenderer.sprite = twisted;
            yield return new WaitForSeconds(0.07f);
            spriteRenderer.sprite = normal;
            yield return new WaitForSeconds(0.07f);
            spriteRenderer.sprite = twisted;
            yield return new WaitForSeconds(0.07f);
            spriteRenderer.sprite = normal;
            yield return new WaitForSeconds(0.07f);
        }
        else if (Random.Range(0, 2) == 1 && isKing)
        {
            spriteRenderer.sprite = twisted;
            transform.position = new Vector3(1.50999999f, -4.63000011f, 0);
            transform.localScale = new Vector3(1.55798554f, 1.55798554f, 1.55798554f);
            yield return new WaitForSeconds(0.07f);
            spriteRenderer.sprite = normal;
            transform.position = new Vector3(0.129999995f, 0.370000005f, 0);
            transform.localScale = new Vector3(0.512191951f, 0.512191951f, 0.512191951f);
            yield return new WaitForSeconds(0.07f);
            spriteRenderer.sprite = twisted;
            transform.position = new Vector3(1.50999999f, -4.63000011f, 0);
            transform.localScale = new Vector3(1.55798554f, 1.55798554f, 1.55798554f);
            yield return new WaitForSeconds(0.07f);
            spriteRenderer.sprite = normal;
            transform.position = new Vector3(0.129999995f, 0.370000005f, 0);
            transform.localScale = new Vector3(0.512191951f, 0.512191951f, 0.512191951f);
            yield return new WaitForSeconds(0.07f);
        }
    }
}
