using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anime;
    public SpriteRenderer sr;
    public int brickNumber;
    [SerializeField] private Text brickText;
    private bool canMove;
    public GameObject screen;
    public CanvasGroup regularUI;
    public static bool notPaused;

    public bool hasGoat;
    public bool hasTelegram;
    public bool hasDegree;
    public bool hasFlag;
    public bool hasCane;
    public bool hasSword;
    public bool hasBook;
    public bool hasChair;

    public int rawScore;
    public int d1Score;
    public int d2Score;
    public int d3Score;
    public int d4Score;
    public int d5Score;
    public int totalScore;

    public Image pausedGoat;
    public Image pausedTelegram;
    public Image pausedDegree;
    public Image pausedFlag;
    public Image pausedCane;
    public Image pausedSword;
    public Image pausedBook;
    public Image pausedChair;

    [SerializeField] private Text scoreValText;

    // Start is called before the first frame update
    void Start()
    {
        resumeGame();
        brickText.text = brickNumber.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //get inputs from player
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //set the correct animation
            if(movement.x > 0)
            {
                sr.flipX = false;
                anime.SetBool("movingQuestion", true);
            }
            else if (movement.x < 0)
            {
                sr.flipX = true;
                anime.SetBool("movingQuestion", true);
            }
            else if (movement.y != 0)
            {
                anime.SetBool("movingQuestion", true);
            }
            else
            {
            anime.SetBool("movingQuestion", false);
            }
        }

        if (Input.GetKeyDown("p"))
        {
            visualizeNPause();

            StartTalking();
            screen.SetActive(true);

            regularUI.alpha = 0.5f;
            regularUI.interactable = false;
            regularUI.blocksRaycasts = false;

            notPaused = false;

            Time.timeScale = 0f;
        }

        totalScore = rawScore + d1Score + d2Score + d3Score + d4Score + d5Score;

        scoreValText.text = totalScore.ToString();
    }

    void FixedUpdate()    
    {
        if (canMove)
        {
            //Player Movement method
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bricks"))
        {
            Collect_Brick cb = collision.GetComponent<Collect_Brick>();
            brickNumber += cb.brickValue;
            brickText.text = brickNumber.ToString();
            rawScore += 10;
        }

        if (collision.gameObject.CompareTag("Artifact"))
        {
            Collect_Brick cb = collision.GetComponent<Collect_Brick>();
            if(cb.brickValue == 1)
            {
                 hasCane = true;
            }
            if (cb.brickValue == 2)
            {
                hasSword = true;
            }
            if (cb.brickValue == 3)
            {
                hasBook = true;
            }
            if (cb.brickValue == 4)
            {
                hasChair = true;
            }
            rawScore += 20;
        }
    }

    public void StartTalking()
    {
        anime.SetBool("movingQuestion", false);
        canMove = false;
    }

    public void DoneTalking()
    {
        canMove = true;
    }

    public bool exchangeMoney(int shopID, int itemcost)
    {
            if (brickNumber >= itemcost)
            {
                if (shopID == 1)
                {
                    hasGoat = true;
                }
                if (shopID == 2)
                {
                    hasTelegram = true;
                }
                if (shopID == 3)
                {
                    hasDegree = true;
                }
                if (shopID == 4)
                {
                    hasFlag = true;
                }

                brickNumber -= itemcost;
                brickText.text = brickNumber.ToString();

                rawScore += 20;
                return (true);
            }
            else
            {
                return (false);
            }
    }

    public void resumeGame()
    {
        screen.SetActive(false);

        regularUI.alpha = 1f;
        regularUI.interactable = true;
        regularUI.blocksRaycasts = true;

        Time.timeScale = 1f;

        notPaused = true;

        DoneTalking();
    }

    public void endGame()
    {
        print("you exited the game");
    }

    public void loadingValues(int bricks, bool goat, bool telegram, bool degree, bool flag, bool cane, bool sword, bool book, bool chair, int raw, int d1, int d2, int d3, int d4, int d5)
    {
        brickNumber = bricks;
        hasGoat = goat;
        hasTelegram = telegram;
        hasDegree = degree;
        hasFlag = flag;
        hasCane = cane;
        hasSword = sword;
        hasBook = book;
        hasChair = chair;
        rawScore = raw;
        d1Score = d1;
        d2Score = d2;
        d3Score = d3;
        d4Score = d4;
        d5Score = d5;

        brickText.text = brickNumber.ToString();
    }

    public void send2Save()
    {
        SaveData.control.overwroldSaving(brickNumber, hasGoat, hasTelegram, hasDegree, hasFlag, hasCane, hasSword, hasBook, hasChair, rawScore, d1Score, d2Score, d3Score, d4Score, d5Score);
    }

    public void visualizeNPause()
    {
        if (hasGoat)
        {
            Color newColor = pausedGoat.color;
            newColor.a = 1f;
            pausedGoat.color = newColor;
        }
        if (hasTelegram)
        {
            Color newColor = pausedTelegram.color;
            newColor.a = 1f;
            pausedTelegram.color = newColor;
        }
        if (hasDegree)
        {
            Color newColor = pausedDegree.color;
            newColor.a = 1f;
            pausedDegree.color = newColor;
        }
        if (hasFlag)
        {
            Color newColor = pausedFlag.color;
            newColor.a = 1f;
            pausedFlag.color = newColor;
        }
        if (hasCane)
        {
            Color newColor = pausedCane.color;
            newColor.a = 1f;
            pausedCane.color = newColor;
        }
        if (hasSword)
        {
            Color newColor = pausedSword.color;
            newColor.a = 1f;
            pausedSword.color = newColor;
        }
        if (hasBook)
        {
            Color newColor = pausedBook.color;
            newColor.a = 1f;
            pausedBook.color = newColor;
        }
        if (hasChair)
        {
            Color newColor = pausedChair.color;
            newColor.a = 1f;
            pausedChair.color = newColor;
        }
    }

    public void returnPlacement(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
    }
}
