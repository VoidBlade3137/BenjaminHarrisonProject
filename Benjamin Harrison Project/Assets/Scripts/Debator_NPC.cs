using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debator_NPC : MonoBehaviour
{
    public GameObject alert;
    public GameObject challenge;
    public bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        alert.SetActive(false);
        challenge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isReady)
            {
                challenge.SetActive(true);
            }
            else
            {
                alert.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isReady)
            {
                challenge.SetActive(false);
            }
            else
            {
                alert.SetActive(false);
            }
        }
    }
}
