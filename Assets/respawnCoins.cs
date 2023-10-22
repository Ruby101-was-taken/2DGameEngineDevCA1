using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class respawnCoins : MonoBehaviour
{
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (x = tilemap.bounds.min.x; x < tilemap.bounds.max.x; x++)
        {
            for (y = tilemap.bounds.min.y; y < tilemap.bounds.max.y; y++)
            {
                for (z = tilemap.bounds.min.z; z < tilemap.bounds.max.z; z++)
                {

                    tilemap.GetTile(new vector3Int(x, y, z));
                }
            }

        }

    }
}
