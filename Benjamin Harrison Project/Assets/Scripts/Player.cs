using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player control;

    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anime;
    public SpriteRenderer sr;
    public int brickNumber;
    [SerializeField] private Text brickText;
    private bool canMove;

    public bool hasGoat;
    public bool hasTelegram;
    public bool hasDegree;
    public bool hasFlag;
    public bool hasCane;
    public bool hasSword;
    public bool hasBook;
    public bool hasChair;

    //call before start
    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        brickText.text = brickNumber.ToString();
        canMove = true;
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
        if(brickNumber >= itemcost)
        {
            if(shopID == 1)
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
}
