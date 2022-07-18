using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager instance;
    [SerializeField]private Text scoreText, goScoreText, highScore;
    private int currentScore = 0;

    //private string[] LHS = new string[3]{ "HighScore_B", "HighScore_I", "HighScore_I" };
    private enum  LHS { HighScore_B, HighScore_I, HighScore_E }

    string HS;

    // Start is called before the first frame update

    private void Awake()
    {
            if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        scoreText.text = "SCORE: " + 0;
        if (AppManager.Instance.SelectedLevel.Equals(ELevels.BEG))
        {
            HS = ELevels.BEG.ToString();
            //highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore_B",0).ToString();

            Debug.Log(" Beginner");
        }
        else if (AppManager.Instance.SelectedLevel.Equals(ELevels.INTER))
        {
            HS = ELevels.INTER.ToString();
            //highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore_I", 0).ToString();
            Debug.Log(" Intermediate ");
        }
        else if (AppManager.Instance.SelectedLevel.Equals(ELevels.PRO))
        {
            HS = ELevels.PRO.ToString();
            //highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore_E", 0).ToString();
            Debug.Log(" Expert ");
        }

        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt(HS, 0).ToString();

        goScoreText.text = "SCORE: " + currentScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        currentScore += 10;
        scoreText.text = "SCORE: " + currentScore;
        goScoreText.text = "SCORE: " + currentScore;

        if (currentScore > PlayerPrefs.GetInt(HS,0))
        {
            PlayerPrefs.SetInt(HS, currentScore);
                highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt(HS, 0);

                Debug.Log(" "+  HS);
        }

        //if (AppManager.Instance.SelectedLevel.Equals(ELevels.BEG) && currentScore > PlayerPrefs.GetInt("HighScore_B", 0))
        //{
        //     PlayerPrefs.SetInt("HighScore_B", currentScore);
        //    highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore_B", 0);

        //    Debug.Log(" Beginner");
        //}
        //else if (AppManager.Instance.SelectedLevel.Equals(ELevels.INTER) && currentScore > PlayerPrefs.GetInt("HighScore_I", 0))
        //{
        //    PlayerPrefs.SetInt("HighScore_I", currentScore);
        //    highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore_I", 0);

        //    Debug.Log(" Intermediate ");
        //}
        //else if (AppManager.Instance.SelectedLevel.Equals(ELevels.PRO) && currentScore > PlayerPrefs.GetInt("HighScore_E", 0))
        //{
        //     PlayerPrefs.SetInt("HighScore_E", currentScore);
        //    highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore_E", 0);

        //    Debug.Log(" Expert ");
        //}
    }
}
