using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class blockSwitch : MonoBehaviour
{

    public bool isOn = true;
    public GameManager gameManager;

    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.swicthOn)
        {
            tilemapRenderer.enabled = !isOn;
            tilemapCollider.enabled = !isOn;
        }
        else
        {
            tilemapRenderer.enabled = isOn;
            tilemapCollider.enabled = isOn;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.swicthOn = isOn;
        }
    }
}
