using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;

public class BulletMovement : MonoBehaviour {

	[HideInInspector]
	public List<Vector3> vectorSpeeds;

	[HideInInspector]
	public float lifeTime = -1;
	float _passedLifeTime;
	bool _isDead = false;

	Vector3 totalSpeed;

	// Use this for initialization
	void Start () {
		_passedLifeTime = 0;
	}

	public void Initialize(){
		_passedLifeTime = 0;
		ClearSpeed ();
	}

	public void SetLifeTime(float lifeTime){
		this.lifeTime = lifeTime;
	}

	void UpdateSpeed(){
		totalSpeed = Vector3.zero;
		for (int i = 0; i < vectorSpeeds.Count; i++)
			totalSpeed += vectorSpeeds [i];
	}

	public void ClearSpeed(){
		vectorSpeeds.Clear ();
		totalSpeed = Vector3.zero;
	}
	public void ApplySpeed(Vector3 speed){
		vectorSpeeds.Add (speed);
		UpdateSpeed ();
	}
	public void RemoveSpeed(int index){
		vectorSpeeds.RemoveAt (index);
		UpdateSpeed ();
	}
	public void RemoveSpeed(Vector3 speed){
		vectorSpeeds.Remove (speed);
		UpdateSpeed ();
	}

	public void ChangeWholeVelocity(Vector3 speed){
		totalSpeed = speed;
	}

	public Vector3 GetWholeVelocity(){
		return totalSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += totalSpeed * Time.deltaTime;
		if (lifeTime != -1) {
			if (_passedLifeTime > lifeTime) {
				if (!_isDead) {
					_isDead = true;
					StartCoroutine(StartDeath ());
				}
			}
			_passedLifeTime += Time.deltaTime;
		}
	}

	IEnumerator StartDeath(){
		//Debug.Log (gameObject.name + " has entered selfdestruction!");
		float _passedDeadTime = 0;
		Color current = GetComponent<Renderer> ().material.color;
		Color target = new Color (current.r, current.g, current.b, 0f);
		//TrailRenderer tr = GetComponent<TrailRenderer>();

		//Color myMaterialColor;
		while (_passedDeadTime < 3f){
			GetComponent<Renderer> ().material.color = Color.Lerp (current, target, _passedDeadTime / 3f);
//			if (GetComponent<TrailRenderer> () != null) {
//				SerializedObject so = new SerializedObject(tr);
//				for (int i = 0; i < 5; i++) {
//					float _alpha = Mathf.Clamp01 (1f - GetComponent<Renderer> ().material.color.a / 4f * i);
//					so.FindProperty("m_Colors.m_Color[" + i.ToString() +"]").colorValue=new Color(myMaterialColor.r,myMaterialColor.g,myMaterialColor.b, _alpha);
//				}
//				so.ApplyModifiedProperties();
//			}
			yield return null;
			_passedDeadTime += Time.deltaTime;
		}
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (_isDead)
			return;
		if (gameObject.CompareTag("myBullet")) {
//			Debug.Log ("Hit!");
//			if (other.CompareTag ("Player")) {
//				Debug.Log ("Hit Player!");
//			}
			//Debug.Log(other.gameObject.name);
			if (other.CompareTag( "Protector")) {
				//Debug.Log ("Hit Protector!");
				//AudioDirector.Instance.PlayHitEnemySound();
//				EnemyHealthBarWatcher.Instance.enemyHealth -= 0.2f + Random.Range (0f, 1f);
//				if (EnemyHealthBarWatcher.Instance.enemyHealth < 0) {
//					//Debug.Log ("Enemy is dead!");
//					WinLoseDeterminer.Instance.YouWin();
//					EnemyHealthBarWatcher.Instance.enemyHealth = 0f;
//				}
				Destroy (gameObject);
				return;
			}


		} else if (gameObject.CompareTag("enemyBullet")) {
			if (other.CompareTag ("Player")) {
				//Debug.Log ("GetHit!");
				//AudioDirector.Instance.PlayPlayerGetHitSound();
//				HealthBarWatcher.Instance.health -= 10f;
//				if (HealthBarWatcher.Instance.health < 0) {
//					WinLoseDeterminer.Instance.YouLose ();
//					HealthBarWatcher.Instance.health = 0f;
//				}
				Destroy (gameObject);
			}
		}
	}
}
