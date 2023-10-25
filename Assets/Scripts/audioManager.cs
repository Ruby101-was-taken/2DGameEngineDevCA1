using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sounds;

    public void Play(string soundName)
    {
        if (soundName.ToLower() == "coin") sounds[0].Play();
        else if (soundName.ToLower() == "evilcoin") sounds[1].Play();
        else if (soundName.ToLower() == "hurt") sounds[2].Play();
        else if (soundName.ToLower() == "switch") sounds[3].Play();
        else if (soundName.ToLower() == "win") sounds[4].Play();
        else if (soundName.ToLower() == "loose") sounds[5].Play();
        else if (soundName.ToLower() == "stamp") sounds[6].Play();
    }
}
