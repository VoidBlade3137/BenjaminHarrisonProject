using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtalk : MonoBehaviour
{
    public Dialouge dialouge;
    public Sprite npcPort;

    void Update()
    {
        if (Player.notPaused)
        {
            if (Input.GetKeyDown("space"))
            {
                if (this.gameObject.tag == "Talkable")
                {
                    FindObjectOfType<Player>().StartTalking();
                    FindObjectOfType<DialougeManager>().StartDialouge(dialouge, npcPort);
                }
                else if (this.gameObject.tag == "Debator")
                {
                    FindObjectOfType<Player>().StartTalking();
                    FindObjectOfType<DialougeManager>().Challenge(dialouge, npcPort);
                }
                else if (this.gameObject.tag == "Shop")
                {
                    FindObjectOfType<Player>().StartTalking();
                    FindObjectOfType<DialougeManager>().StartShopping();
                }
            }
        }
    }
}
