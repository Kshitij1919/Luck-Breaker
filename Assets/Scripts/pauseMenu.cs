using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    //public static bool GameISPaused = false;

    //public GameObject pauseMenuUI= null;


    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if(GameISPaused)
    //        {
    //            Resume();
    //        }
    //        else
    //        {
    //            Pause();
    //        }
    //    }

    //}

    public void ResumeClicked()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        GameController.Instance.SwitchScreen(EGameScreens.GAME);
    }

    public void MainMenuClicked()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        Fader.Instance.ChangeScene(EScene.LEVELSELECTION);
    }

    public void RetryClicked()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        Fader.Instance.ChangeScene(EScene.GAME);
    }
}
