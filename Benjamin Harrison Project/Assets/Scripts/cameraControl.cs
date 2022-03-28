using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform target;
    public Vector2 minPos;
    public Vector2 maxPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 movePos = new Vector3(target.position.x, target.position.y, transform.position.z);

            movePos.x = Mathf.Clamp(movePos.x, minPos.x, maxPos.x);
            movePos.y = Mathf.Clamp(movePos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, movePos, 0.4f);
        }
    }
}
