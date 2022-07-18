using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public ELevels level;
    public LevelButtons instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(int a)
    {
        GameController.Instance.Level = instance.level;
    }
}
