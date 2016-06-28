using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins; 

public class Player : MonoBehaviour 
{
	//character speed when moving
	public float speed;

	private BoxCollider collider;
	private bool xyMode;
	//To know whether the switching is still on process or not
	private bool isSwitchingHappening; 

	// Use this for initialization
	void Start () 
	{
		xyMode = true;

		collider = GetComponent<BoxCollider>();
		collider.size = new Vector3(1, 1, 100);
	}
	
	void OnPlayerRotationFinished ()
	{
		if (xyMode)
		{
			collider.size = new Vector3(1, 100, 1);
		}
		else
		{
			collider.size = new Vector3(1, 1, 100);
		}

		xyMode = !xyMode;

		isSwitchingHappening = false;
	}
	
	void OnEnemiesRotationFinished ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//change dimension
		if(Input.GetKeyDown(KeyCode.Space) && !isSwitchingHappening) 
		{
			if(xyMode) 
			{
				isSwitchingHappening = true;

				//rotate the player and enemies to x rotation to 0
				HOTween.To(this.gameObject.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(-90f,0f,0f), false).OnComplete(OnPlayerRotationFinished).Ease(EaseType.Linear).Delay(0f));
				HOTween.To(GameManager.instance.enemiesGroup.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(-90f,0f,0f), false).OnComplete(OnEnemiesRotationFinished).Ease(EaseType.Linear).Delay(0f));
			}
			else 
			{
				isSwitchingHappening = true;

				//rotate the player and enemies to x rotation to 0
				HOTween.To(this.gameObject.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(0f,0f,0f), false).OnComplete(OnPlayerRotationFinished).Ease(EaseType.Linear).Delay(0f));
				HOTween.To(GameManager.instance.enemiesGroup.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(0f,0f,0f), false).OnComplete(OnEnemiesRotationFinished).Ease(EaseType.Linear).Delay(0f));
			}
		}

		if (Input.GetKey(KeyCode.W))
		{
			this.gameObject.transform.position += new Vector3(0f, 1f, 0f) * speed * Time.deltaTime;
		}
		//else
		if (Input.GetKey(KeyCode.S))
		{
			this.gameObject.transform.position += new Vector3(0f, -1f, 0f) * speed * Time.deltaTime;
		}
		//else
		if (Input.GetKey(KeyCode.A))
		{
			this.gameObject.transform.position += new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
		}
		//else
		if (Input.GetKey(KeyCode.D))
		{
			this.gameObject.transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
		}

		if (this.gameObject.transform.position.x <= -9.4f)
		{
			this.gameObject.transform.position = new Vector3(-9.4f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}

		if (this.gameObject.transform.position.x >= 9.4f)
		{
			this.gameObject.transform.position = new Vector3(9.4f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}

		if (this.gameObject.transform.position.y >= 5.2f)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 5.2f, this.gameObject.transform.position.z);
		}

		if (this.gameObject.transform.position.y <= -5.2f)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -5.2f, this.gameObject.transform.position.z);
		}
	}
}
