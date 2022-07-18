using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    private static AppManager _instance = null;

    public ELevels SelectedLevel = 0;
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
        
    }

    public static AppManager Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

}
