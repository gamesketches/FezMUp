using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HighScores : MonoBehaviour {

	private const string HIGH_SCORE_PATH = "/Scores/";
	public string highScoreFile = "HighScores.txt";

	bool highScoresChanged;

	public void RecalculateHighScores()
	{
		int currentScore = GetComponent<Timer>().TotalTime;

		List<int> highScores = GetOldScores();

		for (int i = 0; i < highScores.Count; i++)
		{
			if (currentScore > highScores[i])
			{
				Debug.Log("Inserting " + currentScore);
				highScores.Insert(i, currentScore);
				ValueHolder.insertPoint = i;
				UpdateHighScoreList(highScores);
				SceneManager.LoadScene("Name entry");
			}

			SceneManager.LoadScene("High scores");
		}
	}

	List<int> GetOldScores()
	{
		string[] oldHighScores = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoreFile, ',');
		List<int> oldScores = new List<int>();

		foreach (string value in oldHighScores) { oldScores.Add(int.Parse(value)); }

		return oldScores;
	}
		
	string revisedScores = "";

	void UpdateHighScoreList(List<int> highScores)
	{
		for (int i = 0; i < ValueHolder.scoresTracked; i++)
		{
			revisedScores += highScores[i].ToString() + ",";
		}

		revisedScores = revisedScores.Trim(',');

		FileIO.WriteStringToFile(Application.dataPath + HIGH_SCORE_PATH + highScoreFile,
								 revisedScores,
								 false);
	}
}
