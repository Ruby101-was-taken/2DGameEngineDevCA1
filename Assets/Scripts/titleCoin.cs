using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleCoin : MonoBehaviour
{
    // moves coins to the right, destroys it when off screen
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 2*Time.deltaTime, transform.position.y, 0);
        if(transform.position.x >= 12)
        {
            Destroy(gameObject);
        }
    }
}
