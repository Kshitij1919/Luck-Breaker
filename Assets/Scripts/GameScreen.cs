using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BackClicked()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        //MenuController.Instance.SwitchScreen(EMenuScreens.HOME);
        Fader.Instance.ChangeScene(EScene.LEVELSELECTION);
    }

    public void GoToPauseScreen()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        GameController.Instance.SwitchScreen(EGameScreens.PAUSE);
    }
}
