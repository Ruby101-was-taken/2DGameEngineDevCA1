using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class switchBlock : MonoBehaviour
{
    public bool isOn = true;
    public GameManager gameManager;

    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider;
    private CompositeCollider2D compositeCollider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
        compositeCollider = GetComponent<CompositeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.swicthOn)
        {
            tilemapRenderer.enabled = isOn;
            tilemapCollider.enabled = isOn;
            compositeCollider.enabled = isOn;
        }
        else
        {
            tilemapRenderer.enabled = !isOn;
            tilemapCollider.enabled = !isOn;
            compositeCollider.enabled = !isOn;
        }
    }
}
