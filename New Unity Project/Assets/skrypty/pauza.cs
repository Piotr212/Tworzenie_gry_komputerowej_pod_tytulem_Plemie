using UnityEngine;
using System.Collections;

public class pauza : MonoBehaviour {
	public bool w_pauzie;//przechowuje wartość logiczną
	public GameObject panel;//przechowuje dane obiektu
	public GameObject panel_zapisu;//przechowuje dane obiektu
	public GameObject panel_wczytania;//przechowuje dane obiektu
	void Start () {
		w_pauzie = false;//zmiana wartości logicznej
		Time.timeScale = 1;//zmiana prędkości czasu
	}
	public void z_pauzy()
	{
		Time.timeScale=1;//zmiana prędkości czasu
		panel.SetActive(false);//desaktywacja obiektu
		panel_zapisu.SetActive (false);//desaktywacja obiektu
		panel_wczytania.SetActive (false);//desaktywacja obiektu
		}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			w_pauzie=!w_pauzie;//zmiana wartości logicznej
			if (w_pauzie) {
				Time.timeScale=0;//zmiana prędkości czasu
				panel.SetActive(true);//aktywowanie obiektu
			}
			else {
				z_pauzy();//uruchomienie funkcji
			}
				}
	
	}
}
