using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowHighScores : MonoBehaviour {

	private const string HIGH_SCORE_PATH = "/Scores/";
	public string highScoreNamesFile = "HighScoreNames.txt";

	List<string> GetNames()
	{
		string[] names = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoreNamesFile, ',');

		List<string> oldNames = new List<string>();

		foreach (string name in names) { oldNames.Add(name); }

		return oldNames;
	}

	void WriteNameList(List<string> nameList)
	{
		string names = "";

		for (int i = 0; i < ValueHolder.scoresTracked; i++) { names += name + ","; }

		names = names.Trim(',');

		FileIO.WriteStringToFile(Application.dataPath + HIGH_SCORE_PATH + highScoreNamesFile,
			names,
			false);
	}
}
