using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<int> refs;
    public Text dialougeText;
    public Animator anime;
    public Image benPort;
    public Image enemyPort;
    public bool portMode;

    public GameObject choices;

    // Start is called before the first frame update
    void Start()
    {
        choices.SetActive(false);
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BacktoGame()
    {
            anime.SetBool("isShopping", false);
            anime.SetBool("isOpen", false);
            FindObjectOfType<Player>().DoneTalking();
    }

    public void StartShopping()
    {
        anime.SetBool("isShopping", true);
    }

    public void StartDialouge(Dialouge dialouge, Sprite npcPort)
    {
        enemyPort.sprite = npcPort;
        anime.SetBool("isOpen", true);
        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DefaultPort();
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
           BacktoGame();
           return;
        }
        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        AlternatePort();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialougeText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }

    private void DefaultPort()
    {
        benPort.enabled = true;
        enemyPort.enabled = false;
        portMode = false;
    }

    private void AlternatePort()
    {
        if(portMode == true)
        {
            portMode = false;
            benPort.enabled = true;
            enemyPort.enabled = false;
            
        }
        else if (portMode == false)
        {
            portMode = true;
            benPort.enabled = false;
            enemyPort.enabled = true;
            
        }
    }

    public void Challenge(Dialouge dialouge, Sprite npcPort)
    {
        StartDialouge(dialouge, npcPort);
        choices.SetActive(true);
    }

    public void Decline()
    {
        BacktoGame();
        StartCoroutine(wait2Disapear());
    }

    IEnumerator wait2Disapear()
    {
        yield return new WaitForSeconds(2);
        choices.SetActive(false);
    }
}
