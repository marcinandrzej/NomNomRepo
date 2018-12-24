using UnityEngine;
using UnityEngine.UI;

public class HighscoreShow : MonoBehaviour
{
    public Text highScore;

	void Start ()
    {
        if (PlayerPrefs.GetInt("SnorlaxScore") >= 0)
            highScore.text = "Highscore: " + PlayerPrefs.GetInt("SnorlaxScore").ToString();
    }
}
