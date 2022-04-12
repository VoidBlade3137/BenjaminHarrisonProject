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

    // Start is called before the first frame update
    void Start()
    {
        brickText.text = brickNumber.ToString();
        canMove = true;
        notPaused = true;
        screen.SetActive(false);
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
            StartTalking();
            screen.SetActive(true);

            regularUI.alpha = 0.5f;
            regularUI.interactable = false;
            regularUI.blocksRaycasts = false;

            notPaused = false;

            Time.timeScale = 0f;
        }
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
}
