using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotes : MonoBehaviour
{
    public string noteType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "noteController")
        {
            FindObjectOfType<DebateEnemy>().moveToBeat(noteType);
            Destroy(this.gameObject);
        }
    }
}
