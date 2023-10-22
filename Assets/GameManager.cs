using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float time;
    public TMP_Text timeText;
    public TMP_Text coinText;

    public CharacterController player; 

    private int coin;

    public Image speedArrow;

    // Start is called before the first frame update
    void Awake()
    {
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        timeText.text = generateTimeText();
    }
    private string generateTimeText()
    {
        string mins = "" + (int)(time / 60);
        if(mins.Length == 1)
        {
            mins = "0" + mins;
        }
        string secs = "" + ((int)time-((int)(time / 60))*60);
        if (secs.Length == 1)
        {
            secs = "0" + secs;
        }

        return mins + ":" + secs;
    }

    public void resetGame()
    {
        time = 0f;
        coin = 0;
        player.moveSpeed = player.normalSpeed;
        speedArrow.rectTransform.rotation = Quaternion.Euler(0, 0, 130);
        coinText.text = "Coins: 0";
    }

    public void collectCoin(int amount)
    {
        coin += amount;
        coinText.text = "Coins: " + coin;

        player.moveSpeed += (player.normalSpeed * 0.1f) * amount;

        speedArrow.rectTransform.rotation = Quaternion.Euler(0, 0, 130-player.moveSpeed*2);

        if (coin < 0)
        {
            player.kill();
        }
    }
}