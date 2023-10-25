using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCoin : MonoBehaviour
{
    private bool isCollected = false;
    [SerializeField] private bool isOn = true;
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
    private void Update()
    {
        if (!isCollected)
        {
            if (gameManager.swicthOn)
            {
                coll.enabled = isOn;
                sprite.enabled = isOn;
            }
            else
            {
                coll.enabled = !isOn;
                sprite.enabled = !isOn;
            }
        }
    }
    void resetSelf()
    {
        isCollected = false;
        sprite.enabled = true;
        coll.enabled = true;
    }
    void collectSelf()
    {
        isCollected = true;
        sprite.enabled = false;
        coll.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectSelf();
            gameManager.collectCoin(1);
        }
    }


}
