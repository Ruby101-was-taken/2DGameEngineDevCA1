using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilCoin : MonoBehaviour
{
    //same as coin, only differences bein that it does not check for title and it removes coins

    public SpriteRenderer sprite;
    public CircleCollider2D coll;
    public GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        coll = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        resetSelf();
    }
    void resetSelf()
    {
        sprite.enabled = true;
        coll.enabled = true;
    }
    void collectSelf()
    {
        sprite.enabled = false;
        coll.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectSelf();
            gameManager.collectCoin(-1);
        }
    }


}
