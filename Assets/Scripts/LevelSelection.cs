using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToGame(int level)
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        AppManager.Instance.SelectedLevel = (ELevels)level;
        Fader.Instance.ChangeScene(EScene.GAME);
    }

    public void BackClicked()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        Fader.Instance.ChangeScene(EScene.MENU);
    }
}
