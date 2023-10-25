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
        // ngl this way of doig this is probably terrible but it works so yea :3


        //gets the bool from the gamemananger that dictates the state of the switch, then, using the isOn boolm we set the visibliy and collision of the tile layers, doing this prevents having to make many switch objects, and s=instead just uses a single layer
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
        { //toggles the gamemanger's switch bool to whatever the isOn was set to
            gameManager.swicthOn = isOn;
        }
    }
}
