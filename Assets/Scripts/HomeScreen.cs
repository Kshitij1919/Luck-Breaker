using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomeScreen : MonoBehaviour
{

    void Start()
    {
        
    }

    public void GoToLevelSelection()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        Fader.Instance.ChangeScene(EScene.LEVELSELECTION);
    }

    public void GoToCreditsScreen()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        MenuController.Instance.SwitchScreen(EMenuScreens.CREDITS);
        
    }
}
