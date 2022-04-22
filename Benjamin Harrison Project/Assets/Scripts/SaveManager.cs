using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public bool inOverworld;
    public bool inDebate;
    public int debateNumber;
    public GameObject shopGoat;
    public GameObject shopTelegram;
    public GameObject shopDegree;
    public GameObject shopFlag;
    public GameObject overworldPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (inOverworld)
        {
            SaveData.control.givePlayerPosition();
            
            SaveData.control.loadInOverworld(shopGoat, shopTelegram, shopDegree, shopFlag);
        }
        else if (inDebate)
        {
            SaveData.control.loadInRhythm();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitButton()
    {
        if (inOverworld)
        {
            FindObjectOfType<Player>().send2Save();
            SaveData.control.exit();
        }
        else if (inDebate)
        {
            SaveData.control.exit();
        }
        SceneManager.LoadScene(0);
    }

    public void sceneChangeSaving()
    {
        if (inOverworld)
        {
            FindObjectOfType<Player>().send2Save();
        }
        else if (inDebate)
        {
            SaveData.control.rhythmSaving(debateNumber);
        }
    }

    public void startGame()
    {
        SaveData.control.newGame();
        SceneManager.LoadScene(1);
    }

    public void resumeGame()
    {
        if(PlayerPrefs.GetInt("GameData", 0) == 1)
        {
            SaveData.control.continueGame();
            SceneManager.LoadScene(PlayerPrefs.GetInt("Scene", 1));
        }
        else
        {
            print("there is no save data to load");
        }
    }

    public void Accepted()
    {
        SaveData.control.getPlayerPosition(overworldPlayer);
        sceneChangeSaving(); 
        SceneManager.LoadScene(debateNumber);
    }
}
