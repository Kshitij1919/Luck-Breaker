using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private static Fader _instance = null;
    private string[] states = { "idle", "in", "out" };

    private enum EState { IDLE, IN, OUT};

    [SerializeField]private Animator animRef = null;

    private EState state;

    private bool sceneLoaded = false;

    private EScene sceneToLoad;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;

            //Init
            //Init();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState = EState.IDLE;
    }

    public static Fader Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private EState ChangeState
    {
        get { return state; }
        set
        {
            state = value;
            animRef.SetTrigger(states[(int)state]);
        }
    }

    public void ChangeScene(EScene _scene)
    {
        sceneToLoad = _scene;
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        sceneLoaded = false;

        ChangeState = EState.IN;
        yield return new WaitUntil(() => sceneLoaded == true);
        ChangeState = EState.OUT;
    }

    private void OnFadeInDone()
    {
        SceneManager.LoadScene((int)sceneToLoad);
    }

    private void OnFadeOutDone()
    {
        ChangeState = EState.IDLE;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneLoaded = true;
    }
}
