using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public bool inOverworld;
    public bool inDebate;
    public int debateNumber;
    public GameObject shopGoat;
    public GameObject shopTelegram;
    public GameObject shopDegree;
    public GameObject shopFlag;

    // Start is called before the first frame update
    void Start()
    {
        if (inOverworld)
        {
            FindObjectOfType<SaveData>().loadInOverworld(shopGoat, shopTelegram, shopDegree, shopFlag);
        }
        else if (inDebate)
        {
            FindObjectOfType<SaveData>().loadInRhythm();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        if (inOverworld)
        {
            FindObjectOfType<SaveData>().overwroldSaving();
        }
        else if (inDebate)
        {
            FindObjectOfType<SaveData>().rhythmSaving(debateNumber);
        }
    }
}
