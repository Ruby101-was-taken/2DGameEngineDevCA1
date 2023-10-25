using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private resultManager resultManager;
    [HideInInspector] public float time;
    public TMP_Text timeText;
    public TMP_Text coinText;

    public CharacterController player; 

    private int coin;

    public RawImage speedArrow;

    [HideInInspector] public bool swicthOn;

    [SerializeField] private Canvas HUD;
    [SerializeField] private Canvas results;

    private float finalTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        resetGame(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        timeText.text = generateTimeText();
    }
    private string generateTimeText()
    {
        string mins = "" + (int)(time / 60); //gets the minutes by casting the seconds divided by 60 into an int, then making it a string
        if(mins.Length == 1)
        {
            mins = "0" + mins;  //adds ectra 0 if the number is less then 10, aka the number is a single digit
        }
        string secs = "" + ((int)time-((int)(time / 60))*60); //gets seconds by removing the minutes multiplied by the total seconds as an int
        if (secs.Length == 1)
        {
            secs = "0" + secs; //adds ectra 0 if the number is less then 10, aka the number is a single digit
        }

        return mins + ":" + secs; // returns string in format MM:SS
    }

    public void resetGame(bool resetScene)
    {
        HUD.enabled = true;   // enables HUD and disables result screen so that only the HUD is visible and nothing else 
        results.enabled = false;
        time = 0f;
        coin = 0;
        player.moveSpeed = player.normalSpeed;
        speedArrow.rectTransform.rotation = Quaternion.Euler(0, 0, 130); //resets spedometer
        coinText.text = "Coins: 0";
        swicthOn = true; //this is for the on off blocks, you know? The green and pink ones, with the '!' on them
        if (resetScene) //this is mainly for the start call of this cuz that means that the code gets in a silly infinite loop and that is bad apparently 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void collectCoin(int amount)
    {
        coin += amount;
        coinText.text = "Coins: " + coin;

        player.moveSpeed += (player.normalSpeed * 0.1f) * amount; //increase player speed for every coin

        speedArrow.rectTransform.rotation = Quaternion.Euler(0, 0, 130-player.moveSpeed*2); //updates spedometer arrow

        if (coin < 0)
        {
            player.kill(); //kills if the player doesn't have enough coins
        }
    }

    public void removeCoins()
    {
        if (coin > 0) 
        {
            collectCoin(-coin);
        }
        else
        { //just kills player if they don't got enough coins L
            player.kill();
        }
    }

    public void finishLevel()
    { //does the opposite of lines 58 & 59 (line numbers subject to change T's&C's apply)
        results.enabled = true;
        HUD.enabled = false;
        //starts the results manager's stuff
        resultManager.getResults(time, generateTimeText());
    }
}
