using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static int score = 0;
    public static int highscore = 0;
    public int slavCountCurrent = 0;
    public static int slavCountRemaining = 0;


    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

}
