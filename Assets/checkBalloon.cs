using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBalloon : MonoBehaviour
{
    public CharacterController player;
    private Vector3 balloonPos = new Vector3(0, 0, 0);
    private void Update()
    {
        if(!player.isGrounded && Input.GetKeyDown(KeyCode.Space)) player.startHoming(balloonPos);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Balloon")
        {
            Vector3 balloonPos = collider.transform.position;
        }
    }
}
