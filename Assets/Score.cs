using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public static int score = 0;
    private Text myText;

    void Start()
    {
        myText = GetComponent<Text>();
        myText.text = score.ToString();
    }

    public void ScoreIncrementor(int points)
    {
        score += points;
        myText.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }
}
