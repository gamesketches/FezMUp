using UnityEngine;
using System.Collections;
//using UnityEditor;

public class BulletColor : MonoBehaviour {

	[HideInInspector]
	public Color32 basicColor;
	Material trailRendererMaterial;

	// Use this for initialization
	void Start () {
		
		if (trailRendererMaterial == null) {
			Debug.Log ("NO!");
		}
	}

//	public void SetColor_backUp(Color32 myColor){
//		
//		basicColor = new Color32 (myColor.r, myColor.g, myColor.b, 255);
//		//GetComponent<Renderer> ().material.color = basicColor;
//
//
//		GetComponent<Renderer>().material.SetColor("_Color", basicColor);
//		GetComponent<Renderer>().material.SetColor("_EmissionColor", basicColor);
//		TrailRenderer tr = GetComponent<TrailRenderer>();
//		if (GetComponent<TrailRenderer> () != null) {
//			SerializedObject so = new SerializedObject(tr);
//			for (int i = 0; i < 5; i++) {
//				byte _alpha = (byte)(255 - 63 * i);
//				so.FindProperty("m_Colors.m_Color[" + i.ToString() +"]").colorValue=new Color32(basicColor.r,basicColor.g,basicColor.b, _alpha);
//			}
//			so.ApplyModifiedProperties();
//		}
//	}
//
//
//	public void SetColor_backUp(Color myColor){
//		Color32 _myColor = myColor;
//		basicColor = new Color32 (_myColor.r, _myColor.g, _myColor.b, 255);
//		//GetComponent<Renderer> ().material.color = basicColor;
//		GetComponent<Renderer>().material.SetColor("_Color", basicColor);
//		GetComponent<Renderer>().material.SetColor("_EmissionColor", basicColor);
//
//		TrailRenderer tr = GetComponent<TrailRenderer>();
//		if (GetComponent<TrailRenderer> () != null) {
//			SerializedObject so = new SerializedObject(tr);
//			for (int i = 0; i < 5; i++) {
//				byte _alpha = (byte)(255 - 63 * i);
//				so.FindProperty("m_Colors.m_Color[" + i.ToString() +"]").colorValue=new Color32(basicColor.r,basicColor.g,basicColor.b, _alpha);
//			}
//			so.ApplyModifiedProperties();
//		}
//	}


	public void SetColor(Color32 myColor){
		trailRendererMaterial =  new Material(Shader.Find("Particles/Additive"));
		basicColor = new Color32 (myColor.r, myColor.g, myColor.b, 255);


		GetComponent<Renderer>().material.SetColor("_Color", basicColor);
		GetComponent<Renderer>().material.SetColor("_EmissionColor", basicColor);
		trailRendererMaterial.SetColor("_TintColor", basicColor);
		TrailRenderer tr = GetComponent<TrailRenderer>();
		tr.material = trailRendererMaterial;

//		if (GetComponent<TrailRenderer> () != null) {
//			SerializedObject so = new SerializedObject(tr);
//			for (int i = 0; i < 5; i++) {
//				byte _alpha = (byte)(255 - 63 * i);
//				so.FindProperty("m_Colors.m_Color[" + i.ToString() +"]").colorValue=new Color32(basicColor.r,basicColor.g,basicColor.b, _alpha);
//			}
//			so.ApplyModifiedProperties();
//		}
	}

	public void SetColor(Color myColor){
		trailRendererMaterial =  new Material(Shader.Find("Particles/Additive"));
		Color32 _myColor = myColor;
		basicColor = new Color32 (_myColor.r, _myColor.g, _myColor.b, 255);
		//GetComponent<Renderer> ().material.color = basicColor;
		GetComponent<Renderer>().material.SetColor("_Color", basicColor);
		GetComponent<Renderer>().material.SetColor("_EmissionColor", basicColor);
		Color c = basicColor;
		trailRendererMaterial.SetColor("_TintColor", c);
		TrailRenderer tr = GetComponent<TrailRenderer>();
		tr.material = trailRendererMaterial;
//		if (GetComponent<TrailRenderer> () != null) {
//			SerializedObject so = new SerializedObject(tr);
//			for (int i = 0; i < 5; i++) {
//				byte _alpha = (byte)(255 - 63 * i);
//				so.FindProperty("m_Colors.m_Color[" + i.ToString() +"]").colorValue=new Color32(basicColor.r,basicColor.g,basicColor.b, _alpha);
//			}
//			so.ApplyModifiedProperties();
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
