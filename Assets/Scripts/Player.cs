using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//character speed when moving
	public float speed;

	private BoxCollider collider;
	private bool xyMode;

	// Use this for initialization
	void Start () 
	{
		xyMode = true;

		collider = GetComponent<BoxCollider>();
		collider.size = new Vector3(1, 1, 100);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//change dimension
		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			if(xyMode) 
			{
				collider.size = new Vector3(1, 100, 1);
			}
			else 
			{
				collider.size = new Vector3(1, 1, 100);
			}

			xyMode = !xyMode;
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
