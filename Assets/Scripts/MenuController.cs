using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private static MenuController _instance = null;

    [SerializeField] EMenuScreens ActiveScreen;

    [SerializeField] GameObject[] menuScreens;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //AdManager.Instance.ShowBannerAd();
        Init();
    }

    void Init()
    {
        SoundManager.Instance.PlayBackgroundMusic(EGameMusic.MUSIC_MENU);
        SwitchScreen(ActiveScreen);
    }

    public static MenuController Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    public void SwitchScreen(EMenuScreens val)
    {
        for(int i=0; i<menuScreens.Length; i++)
        {
            if(i==(int)val)
            {
                menuScreens[i].SetActive(true);
            }
            else
            {
                menuScreens[i].SetActive(false);
            }
        }
    }
    
}
