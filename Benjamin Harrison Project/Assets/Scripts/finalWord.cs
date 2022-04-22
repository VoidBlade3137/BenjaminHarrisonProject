using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalWord : MonoBehaviour
{
    public bool hitable;

    public KeyCode keyNeeded1;
    public KeyCode keyNeeded2;

    public string noteType;

    public static bool notStopped2 = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyNeeded1) || Input.GetKeyDown(keyNeeded2))
        {
            if (hitable)
            {
                if (notStopped2)
                {
                    FindObjectOfType<DebatePlayer>().finalDebateWords(noteType);
                    GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "noteController")
        {
            hitable = true;
        }

        if (other.tag == "missed")
        {
            FindObjectOfType<DebatePlayer>().finalMissed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "noteController")
        {
            hitable = false;
        }
    }
}
