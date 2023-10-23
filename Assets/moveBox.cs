using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBox : MonoBehaviour
{
    private float startPos;
    [SerializeField] private float moveBy = 10;
    [SerializeField] private bool moveSide = false;
    [SerializeField] private float speed = 1;

    private bool leaveStart = true;
    // Start is called before the first frame update
    void Start()
    {
        if (moveSide)
            startPos = transform.position.x;
        else
            startPos = transform.position.y;

        leaveStart = moveBy > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (leaveStart)
        {
            if (moveSide)
            {
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, 0);
                if(transform.position.x >= startPos + moveBy)
                {
                    leaveStart = false;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), 0);
                if (transform.position.y >= startPos + moveBy)
                {
                    leaveStart = false;
                }
            }
        }
        else
        {
            if (moveSide)
            {
                transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
                if (transform.position.x <= startPos)
                {
                    leaveStart = true;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), 0);
                if (transform.position.y <= startPos)
                {
                    leaveStart = true;
                }
            }
        }
    }
}
