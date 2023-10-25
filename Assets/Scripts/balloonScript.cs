using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonScript : MonoBehaviour
{
    [HideInInspector] public bool popped = false;

    private float popTimer = 0;

    public SpriteRenderer sprite;
    public CircleCollider2D balloonCollider;
    private void Start()
    {
        popped = false;
        popTimer = 0;
        sprite.enabled = true;
        balloonCollider.enabled = true;
    }

    private void Update()
    {
        if (popTimer > 0) { popTimer -= 1 * Time.deltaTime; Debug.Log(popTimer); }
        else if (popTimer < 0)
        {
            popped = false;
            popTimer = 0;
            sprite.enabled = true;
            balloonCollider.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            popped = true;
            popTimer = 10;
            sprite.enabled = false;
            balloonCollider.enabled = false;
        }
    }
}
