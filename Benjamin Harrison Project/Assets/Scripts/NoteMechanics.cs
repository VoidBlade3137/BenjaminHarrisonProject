using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMechanics : MonoBehaviour
{
    public bool hitable;

    public KeyCode keyNeeded1;
    public KeyCode keyNeeded2;

    public string noteType;

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
                FindObjectOfType<DebatePlayer>().moveToBeat(noteType);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "noteController")
        {
            hitable = true;
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
