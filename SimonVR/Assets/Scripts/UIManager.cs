using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    // Start is called before the first frame update
    void Start()
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

    /*
    public void UpdateUI()
    {
        baloonsPoppedUI.text = GameManager.Instance.poppedBalloons + "/" + GameManager.Instance.balloonsInScene;
        currentGameScoreText.text = GameManager.Instance.getCurrentScore;
        highScoreText.text = GameManager.Instance.getHighScore;
    }
    */

}
