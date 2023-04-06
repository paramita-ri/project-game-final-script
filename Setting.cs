using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public AudioMixer mainMixer;
    public void FullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void Volume(float volume){
        mainMixer.SetFloat("volume", volume);
    }
    
}
