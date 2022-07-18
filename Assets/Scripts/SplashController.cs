using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{

    void Start()
    {
        Invoke("GoToMenu", 2f);
    }

    void GoToMenu()
    {
        //SceneManager.LoadScene("Menu");
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        Fader.Instance.ChangeScene(EScene.MENU);
    }

    //IEnumerator GoToMenu()
    //{
    //    yield return new WaitForSeconds(3f);
    //    SceneManager.LoadScene("Menu");
    //}
}
