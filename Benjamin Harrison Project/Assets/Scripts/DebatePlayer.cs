using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebatePlayer : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImg;
    public Sprite pointImg;

    public bool havingGoat;
    public GameObject UpGoat;
    public GameObject LeftGoat;
    public GameObject RightGoat;
    public GameObject DownGoat;

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
        noGoats();

        SR.sprite = pointImg;

        if (havingGoat)
        {
            if (noteType == "left")
            {
                LeftGoat.SetActive(true);
            }
            if (noteType == "right")
            {
                RightGoat.SetActive(true);
            }
            if (noteType == "up")
            {
                UpGoat.SetActive(true);
            }
            if (noteType == "down")
            {
                DownGoat.SetActive(true);
            }
        }

        debateScore++;
        scoreText.text = debateScore.ToString();

        StartCoroutine(returnToNormal());
    }

    IEnumerator returnToNormal()
    {
        yield return new WaitForSeconds(.2f);
        SR.sprite = defaultImg;

        yield return new WaitForSeconds(2f);
        noGoats();
    }

    private void noGoats()
    {
        if (havingGoat)
        {
            LeftGoat.SetActive(false);
            RightGoat.SetActive(false);
            UpGoat.SetActive(false);
            DownGoat.SetActive(false);
        }
    }
}
