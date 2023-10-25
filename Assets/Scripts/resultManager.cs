using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class resultManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private audioManager SFX;

    [SerializeField] private TMP_Text finalTime;
    [SerializeField] private TMP_Text rank;
    [SerializeField] private TMP_Text allRank;

    private string winLoose;

    bool onResults = false;
    private float revealCounter = 3f;
    private float time;

    private bool stamped = false, celebrate = false;

    private void Start()
    {
        onResults = false;
        revealCounter = 3f;
    }

    public void getResults(float time, string timeText)
    {
        rank.enabled = false;
        allRank.enabled = false; //makes sure the rank and rank list is hidden on start
        finalTime.text = "Final Time\n" + timeText;

        onResults = true;

        this.time = time;
    }

    private void Update()
    {
        if (revealCounter <= 1)
        {
            if (!stamped)
            {
                SFX.Play("stamp");
                stamped = true;
            }
            //checks rank compared to set times, then sets text and shows it
            if (time <= 30)
            {
                winLoose = "win";
                Debug.Log("S");
                rank.text = "S";
            }
            else if (time <= 40)
            {
                winLoose = "win";
                Debug.Log("A");
                rank.text = "A";
            }
            else if (time <= 46)
            {
                winLoose = "loose";
                Debug.Log("B");
                rank.text = "B";
            }
            else if (time <= 61)
            {
                winLoose = "loose";
                Debug.Log("C");
                rank.text = "C";
            }
            else if (time <= 91)
            {
                winLoose = "loose";
                Debug.Log("D");
                rank.text = "D";
            }
            else
            {
                winLoose = "loose";
                Debug.Log("E");
                rank.text = "E";
            }
            allRank.enabled = true;
            if (revealCounter <= 0) { 
                rank.enabled = true;
                if (!celebrate)
                {
                    SFX.Play(winLoose);
                    celebrate = true;
                }
            }
            else
                revealCounter -= Time.deltaTime;
        }   
        else if(onResults){
            //counts the timer down only if on results sreen
            revealCounter -= Time.deltaTime;
        }
    }
}
