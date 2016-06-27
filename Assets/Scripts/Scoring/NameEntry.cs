using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NameEntry : MonoBehaviour {

	private const string HIGH_SCORE_PATH = "/Scores/";
	public string highScoreNamesFile = "HighScoreNames.txt";

	InputField nameField;

	void Start()
	{
		nameField = GameObject.Find("Name field").GetComponent<InputField>();
		nameField.ActivateInputField();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			UpdateNameList(nameField.text);
		}
	}

	void UpdateNameList(string newName)
	{
		List<string> nameList = GetNames();

		nameList.Insert(ValueHolder.insertPoint, newName);

		WriteNameList(nameList);
	}

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
		SceneManager.LoadScene("High scores");
	}
}
