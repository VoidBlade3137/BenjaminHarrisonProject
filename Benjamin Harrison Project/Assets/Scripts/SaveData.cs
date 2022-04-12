using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public static SaveData control;

    public int bricks;
    public bool goat;
    public bool telegram;
    public bool degree;
    public bool flag;
    public bool cane;
    public bool sword;
    public bool book;
    public bool chair;
    public int raw;
    public int d1;
    public int d2;
    public int d3;
    public int d4;
    public int d5;

    //call before start
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadInOverworld(GameObject shopGoat, GameObject shopTelegram, GameObject shopDegree, GameObject shopFlag)
    {
        FindObjectOfType<Player>().loadingValues(bricks, goat, telegram, degree, flag, cane, sword, book, chair, raw, d1, d2, d3, d4, d5);

        if (goat == true)
        {
            shopGoat.GetComponent<ShopManager>().Bought();
        }
        if (telegram == true)
        {
            shopTelegram.GetComponent<ShopManager>().Bought();
        }
        if (degree == true)
        {
            shopDegree.GetComponent<ShopManager>().Bought();
        }
        if (flag == true)
        {
            shopFlag.GetComponent<ShopManager>().Bought();
        }
    }

    public void loadInRhythm()
    {
        FindObjectOfType<DebatePlayer>().hasGoat = goat;
    }

    public void overwroldSaving()
    {
        
    }

    public void rhythmSaving(int debateNumber)
    {
        if(debateNumber == 1)
        {
            d1 = FindObjectOfType<DebatePlayer>().debateScore;
        }
        if (debateNumber == 2)
        {
            d2 = FindObjectOfType<DebatePlayer>().debateScore;
        }
        if (debateNumber == 3)
        {
            d3 = FindObjectOfType<DebatePlayer>().debateScore;
        }
        if (debateNumber == 4)
        {
            d4 = FindObjectOfType<DebatePlayer>().debateScore;
        }
        if (debateNumber == 5)
        {
            d5 = FindObjectOfType<DebatePlayer>().debateScore;
        }
    }
}
