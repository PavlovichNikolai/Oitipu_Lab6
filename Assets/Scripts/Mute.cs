using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{

    private bool isMuted = false;




    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;

    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        //PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0); 
        if (isMuted)
        {
            PlayerPrefs.SetInt("MUTED", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MUTED", 0);
        }
    }
}
