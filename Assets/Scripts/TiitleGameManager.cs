using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleGameManager : MonoBehaviour
{

    //This is a dumbed down version of the gamemanger that is usually used, so that it works in the titlescreen
    [SerializeField] private audioManager SFX;

    public CharacterController player; 

    private int coin;

    private float finalTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        resetGame(false);
    }

    public void resetGame(bool resetScene)
    {
        coin = 0;
        player.moveSpeed = player.normalSpeed;
        if (resetScene)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void collectCoin(int amount)
    {
        coin += amount;
        SFX.Play("coin");
        player.anim.speed += 0.1f * amount;
        player.moveSpeed += (player.normalSpeed * 0.1f) * amount;
    }
}
