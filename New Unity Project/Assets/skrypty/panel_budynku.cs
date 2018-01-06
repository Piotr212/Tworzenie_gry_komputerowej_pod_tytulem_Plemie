using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class panel_budynku : MonoBehaviour {
	public GameObject panel_produkcyjny;//przechowuje dane obiektu
	private Canvas can;//przechowuje komponent 
	public Camera kamera;//przechowuje dane kamery
	private float dystans;//przechowuje wartość liczbową rzeczywistą
	public GameObject budynek;//przechowuje dane obiektu
	private GameObject postać;//przechowuje dane obiektu
	void Start () {
		kamera = GameObject.Find ("Main Camera").GetComponent<Camera>();//przypisowuje kamere
		can = panel_produkcyjny.GetComponent<Canvas> ();//przypisuje komponent
		can.worldCamera = kamera;//przypisuje kamerę do komponentu
		postać = GameObject.Find ("Postac");//wyszukuje i przypisuje obiekt
	}
	void Update () {
		dystans = Vector3.Distance (postać.transform.position,budynek.transform.position);//wylicza odległość pomiędzy obiektami
		if (dystans<4f&&Input.GetButton("użycie")) {
			panel_produkcyjny.SetActive(true);//aktywuje obiekt
				}
		else {
			panel_produkcyjny.SetActive(false);//desaktywuje obiekt
				}
	}
}
