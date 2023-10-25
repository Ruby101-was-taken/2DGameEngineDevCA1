using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleCoinSpawer : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private float spawnOffsetX;
    private float timer = 0;

    private void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(coin, new Vector3(-13 + spawnOffsetX, transform.position.y, 0), Quaternion.identity);
            timer = Random.Range(2, 4);
            transform.position = new Vector3(-13, Random.Range(-5, 5), 0);
        }
    }
}
