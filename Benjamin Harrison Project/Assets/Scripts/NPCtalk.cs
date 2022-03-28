using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtalk : MonoBehaviour
{
    public Dialouge dialouge;

    void Update()
    {
        if (Player.notPaused)
        {
            if (Input.GetKeyDown("space"))
            {
                if (this.gameObject.tag == "Talkable")
                {
                    FindObjectOfType<Player>().StartTalking();
                    FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
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
