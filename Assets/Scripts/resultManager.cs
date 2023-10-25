using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class resultManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TMP_Text finalTime;
    [SerializeField] private TMP_Text rank;
    [SerializeField] private TMP_Text allRank;

    bool onResults = false;
    private float revealCounter = 3f;
    private float time;

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
            //checks rank compared to set times, then sets text and shows it
            if (time <= 29)
            {
                Debug.Log("S");
                rank.text = "S";
                rank.color = new Color(255, 190, 0);
            }
            else if (time <= 39)
            {
                Debug.Log("A");
                rank.text = "A";
                rank.color = new Color(255, 255, 0);
            }
            else if (time <= 45)
            {
                Debug.Log("B");
                rank.text = "B";
                rank.color = new Color(153, 153, 153);
            }
            else if (time <= 60)
            {
                Debug.Log("C");
                rank.text = "C";
                rank.color = new Color(153, 92, 70);
            }
            else if (time <= 90)
            {
                Debug.Log("D");
                rank.text = "D";
                rank.color = new Color(255, 40, 0);
            }
            else
            {
                Debug.Log("E");
                rank.text = "E";
                rank.color = new Color(63, 16, 0);
            }
            if(revealCounter <= 0)
                allRank.enabled = true;
            else
                revealCounter -= Time.deltaTime;
        }   
        else if(onResults){
            //counts the timer down only if on results sreen
            revealCounter -= Time.deltaTime;
        }
    }
}
