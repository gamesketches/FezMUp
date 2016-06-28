using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BulletController : MonoBehaviour {


	public List<Transform> prefabBullets;

	[HideInInspector]
	public List<Transform>myBullets;

	List<Action> bulletPatterns;

	// Use this for initialization
	void Start () {
//		Cursor.visible = false;
//		Cursor.lockState = CursorLockMode.Locked;

		bulletPatterns = new List<Action> ();
		bulletPatterns.Add (Pattern_01);
		bulletPatterns.Add (Pattern_02);
		bulletPatterns.Add (Pattern_03);
		bulletPatterns.Add (Pattern_04);
		bulletPatterns.Add (Pattern_05);
		bulletPatterns.Add (Pattern_07);
		bulletPatterns.Add (Pattern_06);
		StartCoroutine(StartWholePattern ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator StartWholePattern(){
		int i = 0;
		while (true) {
			bulletPatterns [i] ();
			i++;
			if (i == bulletPatterns.Count)
				i = 0;
			if (i == 5)
				yield return new WaitForSeconds (5f);
			yield return new WaitForSeconds (10f);
		}
	}

	void Pattern_01(){
		Vector3 pos;
		Transform tbullet;
//		//AudioDirector.Instance.PlayFireworkSound ();
		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 20f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 20f) {
				pos = 20f * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos);
				tbullet.GetComponent<BulletColor> ().SetColor (Color.red);
				myBullets.Add (tbullet);
			}
		}
	}

	void Pattern_02(){
		StopCoroutine (Pattern02SubRoutine ());
		StartCoroutine (Pattern02SubRoutine());
		
	}
	IEnumerator Pattern02SubRoutine(){
		Vector3 origin = new Vector3(0,0,1) * 50f;
		Vector3 pos;
		Transform tbullet;
//		//AudioDirector.Instance.PlayFireworkSound ();
		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 10f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xFF,0x30,0x30,0xFF));
				myBullets.Add (tbullet);
			}
		}
		origin = new Vector3(0,0,-1)* 50f;
		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 10f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xFF,0x30,0x30,0xFF));
				myBullets.Add (tbullet);
			}
		}

		yield return new WaitForSeconds(0.5f);
//		//AudioDirector.Instance.PlayFireworkSound ();
		//Debug.Log ("Hello");

		origin = new Vector3(Mathf.Sin(Mathf.PI / 3f),1,Mathf.Cos(Mathf.PI / 3f)) * 50f;

		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 10f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xFF,0xA3,0x30,0xFF));
				myBullets.Add (tbullet);
			}
		}
		origin = new Vector3(-Mathf.Sin(Mathf.PI / 3f),1,-Mathf.Cos(Mathf.PI / 3f)) * 50f;
		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 10f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xFF,0xA3,0x30,0xFF));
				myBullets.Add (tbullet);
			}
		}


		yield return new WaitForSeconds(0.5f);
//		//AudioDirector.Instance.PlayFireworkSound ();
		origin = new Vector3(Mathf.Sin(Mathf.PI / 3f * 2),1,Mathf.Cos(Mathf.PI / 3f * 2)) * 50f;

		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 10f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xFF,0x68,0x30,0xFF));
				myBullets.Add (tbullet);
			}
		}
		origin = new Vector3(-Mathf.Sin(Mathf.PI / 3f* 2),1,-Mathf.Cos(Mathf.PI / 3f)* 2) * 50f;
		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 10f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xFF,0x68,0x30,0xFF));
				myBullets.Add (tbullet);
			}
		}
	}


	void Pattern_03(){
		StopCoroutine (Pattern03SubRoutine ());
		StartCoroutine (Pattern03SubRoutine());

	}
	IEnumerator Pattern03SubRoutine(){
		Vector3 origin = new Vector3 (0, 0, 1) * 50f;
		Vector3 pos;
		Vector3 speed;
		Transform tbullet;
		for (int i = 0; i < 20; i++) {
			origin = new Vector3 (0f, i * 20f, 0f);
			for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 7f) {
				float theta = Mathf.PI / 3f;
				pos = 1 * new Vector3 (Mathf.Cos (alpha), 0, Mathf.Sin (alpha));
				speed = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos (theta), Mathf.Sin (theta), Mathf.Sin (alpha) * Mathf.Cos (theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed (speed * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32 (0x9B,0x62,0xBF,0xFF));
				myBullets.Add (tbullet);
			}
			//AudioDirector.Instance.PlayFireworkSound ();
			yield return new WaitForSeconds (0.2f);
		}
	}

	void Pattern_04(){
		StopCoroutine (Pattern04SubRoutine ());
		StartCoroutine (Pattern04SubRoutine());

	}
	IEnumerator Pattern04SubRoutine(){
		Vector3 origin = new Vector3 (0, 0, 1) * 50f;
		Vector3 pos;
		Vector3 speed;
		Transform tbullet;

		for (int i = 0; i < 20; i++) {
			origin = new Vector3 (Mathf.Sin(Mathf.PI / 10f* i), i * 0.4f, Mathf.Cos(Mathf.PI / 10f* i)) * 40f;
			speed =  new Vector3 (Mathf.Sin(Mathf.PI / 10f* (i+1)), (i+1) * 0.4f, Mathf.Cos(Mathf.PI / 10f* (i+1))) * 40f - origin;
			tbullet = Instantiate (prefabBullets [0], origin, Quaternion.identity) as Transform;
			tbullet.parent = transform;
			tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
			tbullet.GetComponent<BulletMovement> ().ApplySpeed (speed * 1f);
			tbullet.GetComponent<BulletColor> ().SetColor (new Color32 (0x4E,0xD2,0x6A,0xFF));
			for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
				float theta = 0;
				pos = 1 * new Vector3 (Mathf.Cos (alpha), 0, Mathf.Sin (alpha));
				speed = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos (theta), Mathf.Sin (theta), Mathf.Sin (alpha) * Mathf.Cos (theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed (speed * 20f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32 (0x4E,0xD2,0x6A,0xFF));
				myBullets.Add (tbullet);
			}
			//AudioDirector.Instance.PlayFireworkSound ();
			yield return new WaitForSeconds (0.2f);
		}
	}

	void Pattern_05(){
		StopCoroutine (Pattern05SubRoutine ());
		StartCoroutine (Pattern05SubRoutine());

	}
	IEnumerator Pattern05SubRoutine(){

		List<Transform> theseBullets = new List<Transform> ();
		Vector3 origin = new Vector3 (0, 0, 0);
		Vector3 pos;
		Transform tbullet;
		//AudioDirector.Instance.PlayFireworkSound ();
		for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 5f) {
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 5f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 40f);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xD2,0x4E,0x4E,0xFF));
				myBullets.Add (tbullet);
				theseBullets.Add (tbullet);
			}
		}
		yield return new WaitForSeconds (4f);

		//AudioDirector.Instance.PlayFireworkSound ();
		for (int i = 0; i < theseBullets.Count; i++) {
			origin = theseBullets [i].position;
			for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 5f) {
				for (float theta = -Mathf.PI/2; theta < Mathf.PI/2 ; theta += Mathf.PI / 5f) {
					pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
					tbullet = Instantiate (prefabBullets [0], pos + origin, Quaternion.identity) as Transform;
					tbullet.parent = transform;
					tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
					tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 20f);
					tbullet.GetComponent<BulletColor> ().SetColor (new Color32(0xD2,0x4E,0x4E,0xFF));
					myBullets.Add (tbullet);
					//theseBullets.Add (tbullet);
				}
			}
		}
		theseBullets.Clear ();
	}

	void Pattern_06(){
		StopCoroutine (Pattern06SubRoutine ());
		StartCoroutine (Pattern06SubRoutine());

	}
	IEnumerator Pattern06SubRoutine(){

		List<Transform> theseBullets = new List<Transform> ();
		Vector3 origin = new Vector3 (0, 0, 0);
		Vector3 pos;
		Transform tbullet;

		Vector3 myChanged = Vector3.zero;
		for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 20f) {
			int step = 0;
			for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 10f) {
				pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos(theta), Mathf.Sin (theta), Mathf.Sin (alpha)* Mathf.Cos(theta));
				tbullet = Instantiate (prefabBullets [0], pos * 20 + origin, Quaternion.identity) as Transform;
				tbullet.parent = transform;
				tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
				tbullet.GetComponent<BulletMovement> ().ApplySpeed(pos * 70f);
				tbullet.LookAt (pos+tbullet.position);
				tbullet.GetComponent<BulletColor> ().SetColor (new Color(0.82f,0.305f,1/20f * step,1));
				myBullets.Add (tbullet);
				theseBullets.Add (tbullet);
				step++;
				for (int i = 0; i < theseBullets.Count; i++) {
					tbullet = theseBullets [i];
					myChanged = tbullet.TransformDirection (Vector3.right);
					myChanged.Normalize ();
					tbullet.GetComponent<BulletMovement> ().ChangeWholeVelocity (tbullet.GetComponent<BulletMovement> ().GetWholeVelocity () * 0.99f + myChanged * 40f * 0.01f);
					tbullet.LookAt (tbullet.GetComponent<BulletMovement> ().GetWholeVelocity () + tbullet.position);
				}
				//AudioDirector.Instance.PlayFireworkSound ();
				yield return null;
			}
		}
		float _timePassed = 0;

		while (_timePassed < 4f) {
			foreach (Transform tbullet2 in theseBullets) {
				try{
					myChanged = tbullet2.TransformDirection (Vector3.right);
					myChanged.Normalize ();
					tbullet2.GetComponent<BulletMovement> ().ChangeWholeVelocity (tbullet2.GetComponent<BulletMovement> ().GetWholeVelocity () * 0.99f + myChanged * 40f * 0.01f);
					tbullet2.LookAt (tbullet2.GetComponent<BulletMovement> ().GetWholeVelocity () + tbullet2.position);
				} catch (System.Exception e){
					Debug.LogWarning (e);
				}
			}
			yield return null;
			_timePassed += Time.deltaTime;
		}
		//yield return new WaitForSeconds (4f);

		theseBullets.Clear ();
	}

	void Pattern_07(){
		StopCoroutine (Pattern07SubRoutine ());
		StartCoroutine (Pattern07SubRoutine());

	}
	IEnumerator Pattern07SubRoutine(){

		Vector3 origin = new Vector3 (0, 0, 0);
		Vector3 pos;
		Transform tbullet;

		//Vector3 myChanged = Vector3.zero;
		for (float outerAlpha = 0f; outerAlpha < Mathf.PI * 2; outerAlpha += Mathf.PI / 5f) {
			float outerTheta = Mathf.PI / 3;
			origin = new Vector3 (Mathf.Cos (outerAlpha) * Mathf.Cos (outerTheta), Mathf.Sin (outerTheta), Mathf.Sin (outerAlpha) * Mathf.Cos (outerTheta)) * 100;
			pos = new Vector3 (Mathf.Cos (outerAlpha + Mathf.PI / 5f) * Mathf.Cos (outerTheta), Mathf.Sin (outerTheta), Mathf.Sin (outerAlpha + Mathf.PI / 5f) * Mathf.Cos (outerTheta)) * 100 - origin;
			tbullet = Instantiate (prefabBullets [0],origin, Quaternion.identity) as Transform;
			tbullet.parent = transform;
			tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
			tbullet.GetComponent<BulletMovement> ().ApplySpeed (pos * 0.1f);
			tbullet.GetComponent<BulletColor> ().SetColor (new Color32 (0x4E,0x6B,0xD2,0xFF));
			myBullets.Add (tbullet);
			for (float theta = 0f; theta < Mathf.PI / 2f; theta += Mathf.PI / 5f) {
				for (float alpha = 0f; alpha < Mathf.PI * 2; alpha += Mathf.PI / 5f) {
					pos = 1 * new Vector3 (Mathf.Cos (alpha) * Mathf.Cos (theta), Mathf.Sin (theta), Mathf.Sin (alpha) * Mathf.Cos (theta));
					tbullet = Instantiate (prefabBullets [0], pos * 20 + origin, Quaternion.identity) as Transform;
					tbullet.parent = transform;
					tbullet.GetComponent<BulletMovement> ().SetLifeTime (10f);
					tbullet.GetComponent<BulletMovement> ().ApplySpeed (pos * 70f);
					tbullet.GetComponent<BulletColor> ().SetColor (new Color32 (0x4E,0x6B,0xD2,0xFF));
					myBullets.Add (tbullet);


				}
			}
			//AudioDirector.Instance.PlayFireworkSound ();
			yield return new WaitForSeconds(0.5f);
		}
			
	}

}
