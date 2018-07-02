using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGames : MonoBehaviour {

	void Start ()
	{
		var config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();

		SignIn();
	}

	void SignIn()
	{
		Social.localUser.Authenticate(success => {});
	}

	public static void UnlockAchievement(string id)
	{
		Social.ReportProgress(id, 100, success => {});
	}

	public static void IncrementAchievement(string id, int stepsToIncrement)
	{
		PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => {});
	}

	public static void ShowAchievementsUI()
	{
		Social.ShowAchievementsUI();
	}

	public static void AddScoreToLeaderBoard(string leaderboardId, long score)
	{
		Social.ReportScore(score, leaderboardId, success => {});
	}

	public static void ShowLeaderboardUI()
	{
		Social.ShowLeaderboardUI();
	}
}
