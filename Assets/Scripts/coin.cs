using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public SpriteRenderer sprite;
    public CircleCollider2D coll;
    public GameManager gameManager;
    public TitleGameManager titleGameManager;

    [SerializeField] bool onTitle = false;
    private void Start()
    {
        if(!onTitle) // if the script is in the prefab for title screen coins, it looks for a titleGameManager, otherwise we look for a regular gamemanager
            gameManager = FindObjectOfType<GameManager>();
        else
            titleGameManager = FindObjectOfType<TitleGameManager>();
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
        if(collision.gameObject.tag == "Player")
        {
            collectSelf();
            if(!onTitle)
                gameManager.collectCoin(1);
            else
                titleGameManager.collectCoin(1);
        }
    }


}
