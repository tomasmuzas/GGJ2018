using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static int score = 0;
    public static int highscore = 0;
    public int slavCountCurrent = 0;
    public static int slavCountRemaining = 0;
    public int slavCountNeeded = 15;

    public Text transmittedText;
    public int timeRemaining = 20;
    public GameObject GameOver;


    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        GameOver = GameObject.Find("GameOver");
        GameOver.gameObject.SetActive(false);
    }

    public void AddScore(Praeivis praeivis)
    {
        score += praeivis.Points;
        slavCountCurrent++;
        transmittedText.text = slavCountCurrent + "/" + slavCountNeeded;
    }

    public void End()
    {
        Debug.Log("Game over.");
    }

    void Update()
    {
        //waves_tab.text="Waves:"+wave_current+"/"+wave_all;
        var time = (int)Mathf.Floor(timeRemaining - Time.timeSinceLevelLoad);
        GameObject.Find("TimeLeft").GetComponent<Text>().text = time.ToString();

        if (time <= 0)
        {
            Time.timeScale = 0.0F;
            GameOver.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            GameOver.gameObject.SetActive(true);
        }
    }
}
