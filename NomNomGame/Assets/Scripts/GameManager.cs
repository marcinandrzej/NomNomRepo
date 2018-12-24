using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool end = false;
    private int points = 0;

    public Text scoreText;
    public GameObject endMenu;

	void Start ()
    {
        if (instance == null)
            instance = this;
	}
	
    public bool IsEnd()
    {
        return end;
    }

    public void EndGame()
    {
        end = true;
        if (PlayerPrefs.GetInt("SnorlaxScore") < points)
            PlayerPrefs.SetInt("SnorlaxScore", points);
        endMenu.gameObject.SetActive(true);
    }

    public void AddPoints()
    {
        points++;
        scoreText.text = points.ToString();
    }
}
