using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMechanics : MonoBehaviour
{
    public bool hitable;

    public KeyCode keyNeeded1;
    public KeyCode keyNeeded2;

    public string noteType;

    public static bool notStopped = true;

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
                if (notStopped)
                {
                    FindObjectOfType<DebatePlayer>().moveToBeat(noteType);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "noteController")
        {
            hitable = true;
        }

        if (other.tag == "missed")
        {
            Destroy(this.gameObject);
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
