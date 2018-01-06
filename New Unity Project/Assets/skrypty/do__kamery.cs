using UnityEngine;
using System.Collections;

public class do__kamery : MonoBehaviour {
	public GameObject kamera;//przechowuje dane obiektu
	GameObject panel;//przechowuje dane obiektu
	void Start () {
		kamera = GameObject.Find ("Main Camera"); //przypisuje obiekt
		panel = gameObject;//przypisuje obiekt
	}

	void Update () {
		panel.transform.rotation = Quaternion.Slerp(panel.transform.rotation, Quaternion.LookRotation (kamera.transform.position - panel.transform.position), 10f*Time.deltaTime);//obraca obiekt
}
}