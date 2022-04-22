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
    private int currentScene;
    public bool hasGameData = true;

    public bool hasPositionData;
    public Vector3 spawnPoint;

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

    public void overwroldSaving(int brickNumber, bool hasGoat, bool hasTelegram, bool hasDegree, bool hasFlag, bool hasCane, bool hasSword, bool hasBook, bool hasChair, int rawScore, int d1Score, int d2Score, int d3Score, int d4Score, int d5Score)
    {
        bricks = brickNumber;
        goat = hasGoat;
        telegram = hasTelegram;
        degree = hasDegree;
        flag = hasFlag;
        cane = hasCane;
        sword = hasSword;
        book = hasBook;
        chair = hasChair;
        raw = rawScore;
        d1 = d1Score;
        d2 = d2Score;
        d3 = d3Score;
        d4 = d4Score;
        d5 = d5Score;
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

    public void exit()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        PlayerPrefs.SetInt("BrickNumb", bricks);
        PlayerPrefs.SetInt("Goat", boolToInt(goat));
        PlayerPrefs.SetInt("Tele", boolToInt(telegram));
        PlayerPrefs.SetInt("Degr", boolToInt(degree));
        PlayerPrefs.SetInt("Flag", boolToInt(flag));
        PlayerPrefs.SetInt("Cane", boolToInt(cane));
        PlayerPrefs.SetInt("Sword", boolToInt(sword));
        PlayerPrefs.SetInt("Book", boolToInt(book));
        PlayerPrefs.SetInt("Chair", boolToInt(chair));
        PlayerPrefs.SetInt("RawS", raw);
        PlayerPrefs.SetInt("D1S", d1);
        PlayerPrefs.SetInt("D2S", d2);
        PlayerPrefs.SetInt("D3S", d3);
        PlayerPrefs.SetInt("D4S", d4);
        PlayerPrefs.SetInt("D5S", d5);
        PlayerPrefs.SetInt("Scene", currentScene);
        PlayerPrefs.SetInt("GameData", boolToInt(hasGameData));
    }

    public void newGame()
    {
        PlayerPrefs.DeleteAll();

        bricks = 0;
        goat = false;
        telegram = false;
        degree = false;
        flag = false;
        cane = false;
        sword = false;
        book = false;
        chair = false;
        raw = 0;
        d1 = 0;
        d2 = 0;
        d3 = 0;
        d4 = 0;
        d5 = 0;
        currentScene = 0;
}

    public void continueGame()
    {
        bricks = PlayerPrefs.GetInt("BrickNumb", 0);
        goat = intToBool(PlayerPrefs.GetInt("Goat", 0));
        telegram = intToBool(PlayerPrefs.GetInt("Tele", 0));
        degree = intToBool(PlayerPrefs.GetInt("Degr", 0));
        flag = intToBool(PlayerPrefs.GetInt("Flag", 0));
        cane = intToBool(PlayerPrefs.GetInt("Cane", 0));
        sword = intToBool(PlayerPrefs.GetInt("Sword", 0));
        book = intToBool(PlayerPrefs.GetInt("Book", 0));
        chair = intToBool(PlayerPrefs.GetInt("Chair", 0));
        raw = PlayerPrefs.GetInt("RawS", 0);
        d1 = PlayerPrefs.GetInt("D1S", 0);
        d2 = PlayerPrefs.GetInt("D2S", 0);
        d3 = PlayerPrefs.GetInt("D3S", 0);
        d4 = PlayerPrefs.GetInt("D4S", 0);
        d5 = PlayerPrefs.GetInt("D5S", 0);
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    public void getPlayerPosition(GameObject overworldPlayer)
    {
        spawnPoint = overworldPlayer.transform.position;
        hasPositionData = true;
    }

    public void givePlayerPosition()
    {
        if (hasPositionData)
        {
            FindObjectOfType<Player>().returnPlacement(spawnPoint);
            hasPositionData = false;
        }
    }
}
