using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI classicLastScoreText;

    public TextMeshProUGUI classicHighScoreText1;
    public TextMeshProUGUI classicHighScoreText2;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        //UpdateUI();
    }

    void Start()
    {
        classicHighScoreText1.text = "High Score: " + PlayerPrefs.GetInt("ClassicHighScore").ToString();
        classicHighScoreText2.text = "High Score: " + PlayerPrefs.GetInt("ClassicHighScore").ToString();
        classicLastScoreText.text = "Last Score: " + PlayerPrefs.GetInt("ClassicLastScore").ToString();
    }

    public void UpdateClassicLastScoreText(int lastScore)
    {
        classicLastScoreText.text = "Last Score: " + lastScore.ToString();
    }

    public void UpdateClassicHighScoreText(int highScore)
    {
        classicHighScoreText2.text = "High Score: " + highScore.ToString();
        classicHighScoreText1.text = "High Score: " + highScore.ToString();

    }

    /*
    public void UpdateUI()
    {
        baloonsPoppedUI.text = GameManager.Instance.poppedBalloons + "/" + GameManager.Instance.balloonsInScene;
        currentGameScoreText.text = GameManager.Instance.getCurrentScore;
        highScoreText.text = GameManager.Instance.getHighScore;
    }
    */

}
