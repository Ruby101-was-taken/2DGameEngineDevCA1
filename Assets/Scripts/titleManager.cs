using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene"); //loads game scene
    }
    public void QuitGame()
    {
        Application.Quit(); //closes game, (idk if it works, does nothing when playing in editor)
    }
}
