
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreditsScreen : MonoBehaviour
{

    void Start()
    {

    }

    public void BackClicked()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        MenuController.Instance.SwitchScreen(EMenuScreens.HOME);
        
    }

}
