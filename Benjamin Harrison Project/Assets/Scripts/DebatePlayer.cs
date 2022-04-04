using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebatePlayer : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImg;
    public Sprite leftImg;
    public Sprite rightImg;
    public Sprite upImg;
    public Sprite downImg;

    public bool havingGoat;
    public GameObject theGoat;

    public int debateScore;
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        debateScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveToBeat(string noteType)
    {
        if (noteType == "left")
        {
            SR.sprite = leftImg;
        }
        if (noteType == "right")
        {
            SR.sprite = rightImg;
            if (havingGoat)
            {
                theGoat.SetActive(true);
            }
        }
        if (noteType == "up")
        {
            SR.sprite = upImg;
        }
        if (noteType == "down")
        {
            SR.sprite = downImg;
        }

        debateScore++;
        scoreText.text = debateScore.ToString();

        StartCoroutine(returnToNormal());
    }

    IEnumerator returnToNormal()
    {
        yield return new WaitForSeconds(2);
        SR.sprite = defaultImg;
        if (havingGoat)
        {
            theGoat.SetActive(false);
        }
    }
}
