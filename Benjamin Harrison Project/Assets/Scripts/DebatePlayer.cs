using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebatePlayer : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImg;
    public Sprite pointImg;

    public bool hasGoat;
    public GameObject UpGoat;
    public GameObject LeftGoat;
    public GameObject RightGoat;
    public GameObject DownGoat;

    public int debateScore;
    [SerializeField] private Text scoreText;

    public int connectedLevelID;

    private bool notPaused;
    public GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        debateScore = 0;

        notPaused = true;
        screen.SetActive(false);
        Time.timeScale = 1f;
        NoteMechanics.notStopped = true;
        finalWord.notStopped2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            notPaused = false;
            FindObjectOfType<NoteMovement>().debating = false;
            NoteMechanics.notStopped = false;
            finalWord.notStopped2 = false;

            screen.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void moveToBeat(string noteType)
    {
        if (notPaused)
        {
            noGoats();

            SR.sprite = pointImg;

            if (hasGoat)
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

                debateScore += 5;
            }

            debateScore += 10;
            scoreText.text = debateScore.ToString();

            StartCoroutine(returnToNormal());
        }
       
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
        if (hasGoat)
        {
            LeftGoat.SetActive(false);
            RightGoat.SetActive(false);
            UpGoat.SetActive(false);
            DownGoat.SetActive(false);
        }
    }

    public void finalDebateWords(string noteType)
    {
        if (notPaused)
        {
            moveToBeat(noteType);
            StartCoroutine(deabteEnding());
        } 
    }

    public void finalMissed()
    {
        StartCoroutine(deabteEnding());
    }

    IEnumerator deabteEnding()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<SaveManager>().sceneChangeSaving();
        yield return new WaitForSeconds(1F);
        SceneManager.LoadScene(1);
    }

    public void resumeDebate()
    {
        notPaused = true;
        FindObjectOfType<NoteMovement>().debating = true;
        NoteMechanics.notStopped = true;
        finalWord.notStopped2 = true;

        screen.SetActive(false);

        Time.timeScale = 1f;
    }
}
