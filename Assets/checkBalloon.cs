using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBalloon : MonoBehaviour
{
    public CharacterController player;
    private Vector3 balloonPos = new Vector3(0, 0, 0);

    private int collisions = 0;
    private void Start()
    {
        collisions = 0;
    }
    private void Update()
    {
        if (!player.isGrounded && Input.GetKeyDown(KeyCode.Space) && balloonPos != new Vector3(0, 0, 0))
        {
            player.startHoming(balloonPos);
            balloonPos = new Vector3(0, 0, 0);
        }
        if (collisions == 0)
        {
            balloonPos = new Vector3(0, 0, 0);
        }

        collisions = 0;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        collisions += 1;
        if (collider.gameObject.tag == "Balloon")
        {
            balloonPos = collider.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
