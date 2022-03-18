using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtalk : MonoBehaviour
{
    public Dialouge dialouge;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.gameObject.name == "NPC")
            {
                FindObjectOfType<Player>().StartTalking();
                FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
            }
            else if (hit.collider.gameObject.name == "OpossumShop")
            {
                FindObjectOfType<Player>().StartTalking();
                FindObjectOfType<DialougeManager>().StartShopping();
            }
            else
            {
                return;
            }
        }
    }
}
