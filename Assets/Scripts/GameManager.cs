using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;
	
	[HideInInspector]
	public GameObject enemiesGroup;

	// Use this for initialization
	void Start () 
	{
		instance = this;

		enemiesGroup = GameObject.Find("Enemies");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
