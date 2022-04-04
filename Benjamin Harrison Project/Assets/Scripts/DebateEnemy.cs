using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateEnemy : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImg;
    public Sprite leftImg;
    public Sprite rightImg;
    public Sprite upImg;
    public Sprite downImg;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToBeat(string noteType)
    {
        if(noteType == "left")
        {
            SR.sprite = leftImg;
        }
        if (noteType == "right")
        {
            SR.sprite = rightImg;
        }
        if (noteType == "up")
        {
            SR.sprite = upImg;
        }
        if (noteType == "down")
        {
            SR.sprite = downImg;
        }

        StartCoroutine(returnToNormal());
    }

    IEnumerator returnToNormal()
    {
        yield return new WaitForSeconds(2);
        SR.sprite = defaultImg;
    }
}
