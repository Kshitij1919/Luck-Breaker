using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region --- VARIABLE DECLARATION ---

    private static SoundManager _instance;

    [SerializeField]
    private AudioSource[] audioSource = null;

    [SerializeField] private AudioClip[] backgroundSounds;
    [SerializeField] private AudioClip[] sfxSounds;

    #endregion

    #region --- INITIALIZE ---

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;

            //Init
            Init();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static SoundManager Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    void Init()
    {
        //Background Source
        if (audioSource.Length <= 0)
            Debug.Log("Audio Source Not Found !!!");
        else
        {
            for (int i = 0; i < audioSource.Length; ++i)
            {
                if (i == (int)EAudioSource.AUDIO_SOURCE_BACKGROUND)
                {
                    audioSource[i].playOnAwake = false;
                    audioSource[i].volume = 0.2f;
                    audioSource[i].loop = true;
                }
                else
                {
                    audioSource[i].playOnAwake = false;
                    audioSource[i].volume = 1f;
                    audioSource[i].loop = false;
                }
            }
        }
    }

    #endregion

    #region --- HELPER METHODS

    public void PlayBackgroundMusic(EGameMusic _music)
    {
        if (!isBackgroundMusicPlaying() || (audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].clip.name != backgroundSounds[(int)_music].name))
        {
            audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].clip = backgroundSounds[(int)_music];
            audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].Play();
        }
    }

    public bool isBackgroundMusicPlaying()
    {
        return audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].isPlaying;
    }

    public void SetBackgroundMusicVolume(float _vol)
    {
        audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].volume = _vol;
    }

    public void StopBackgroundMusic()
    {
        audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].Stop();
    }

    public void PauseBackgroundMusic()
    {
        audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].Pause();
        //audioSourceBackground.time = 0f;
    }

    public void ResumeBackgroundMusic()
    {
        audioSource[(int)EAudioSource.AUDIO_SOURCE_BACKGROUND].Play();
        //audioSourceBackground.time = 1f;
    }

    public void PlaySfxSound(EAudioSource _audioSource, EGameSfx _sfx, float _volume)
    {
        audioSource[(int)_audioSource].clip = sfxSounds[(int)_sfx];
        audioSource[(int)_audioSource].volume = _volume;
        audioSource[(int)_audioSource].Play();
    }

    public void PlaySfxSound(EAudioSource _audioSource, EGameSfx _sfx)
    {
        audioSource[(int)_audioSource].clip = sfxSounds[(int)_sfx];
        audioSource[(int)_audioSource].Play();
    }

    public void PlaySfxLoop(EAudioSource _audioSource, EGameSfx _sfx, float _volume, bool _loop)
    {
        audioSource[(int)_audioSource].loop = _loop;
        audioSource[(int)_audioSource].clip = sfxSounds[(int)_sfx];
        audioSource[(int)_audioSource].volume = _volume;
        audioSource[(int)_audioSource].Play();
    }

    public void PlaySfxOneShot(EAudioSource _audioSource, EGameSfx _sfx, float _volume)
    {
        audioSource[(int)_audioSource].PlayOneShot(sfxSounds[(int)_sfx], _volume);
    }

    public void PlaySfxOneShot(EAudioSource _audioSource, EGameSfx _sfx)
    {
        audioSource[(int)_audioSource].PlayOneShot(sfxSounds[(int)_sfx]);
    }

    public bool isSfxPlaying(EAudioSource _audioSource)
    {
        return audioSource[(int)_audioSource].isPlaying;
    }

    public void SetSfxVolume(EAudioSource _audioSource, float _vol)
    {
        audioSource[(int)_audioSource].volume = _vol;
    }

    public void SetAllSfxVolume(float _vol)
    {
        for (int i = 0; i < audioSource.Length; ++i)
        {
            if (i != (int)EAudioSource.AUDIO_SOURCE_BACKGROUND)
                SetSfxVolume((EAudioSource)i, _vol);
        }
    }

    public void StopSfxSound(EAudioSource _audioSource)
    {
        audioSource[(int)_audioSource].Stop();
    }

    public void PauseSfxSound(EAudioSource _audioSource)
    {
        audioSource[(int)_audioSource].Pause();
        //audioSourceSfx.time = 0f;
    }

    public void PauseAllSfxSound()
    {
        for (int i = 0; i < audioSource.Length; ++i)
        {
            if (i != (int)EAudioSource.AUDIO_SOURCE_BACKGROUND)
                PauseSfxSound((EAudioSource)i);
        }
    }

    public void ResumeSfxSound(EAudioSource _audioSource)
    {
        audioSource[(int)_audioSource].Play();
        //audioSourceSfx.time = 1f;
    }

    public void ResumeAllSfxSound()
    {
        for (int i = 0; i < audioSource.Length; ++i)
        {
            if (i != (int)EAudioSource.AUDIO_SOURCE_BACKGROUND)
                ResumeSfxSound((EAudioSource)i);
        }
    }

    public void StopAllSfx()
    {
        for (int i = 0; i < audioSource.Length; ++i)
        {
            if (i != (int)EAudioSource.AUDIO_SOURCE_BACKGROUND)
                StopSfxSound((EAudioSource)i);
        }
    }

    public void StopAll()
    {
        StopBackgroundMusic();
        StopAllSfx();
    }

    public void PauseAll()
    {
        PauseBackgroundMusic();
        PauseAllSfxSound();
    }

    public void ResumeAll()
    {
        ResumeBackgroundMusic();
        ResumeAllSfxSound();
    }

    #endregion

}
