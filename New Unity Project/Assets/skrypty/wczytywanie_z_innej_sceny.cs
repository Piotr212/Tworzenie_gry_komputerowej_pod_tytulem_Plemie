using UnityEngine;
using System.Collections;

public class wczytywanie_z_innej_sceny : MonoBehaviour {
	public string zapis;//przechowuje ciąg znaków
	void Update () {
		if (GameObject.Find ("UI panel")) {
			GameObject panel = GameObject.Find ("UI panel").GetComponent<pauza>().panel_wczytania;//przypisuje obiekt
			panel.GetComponent<wczytywanie_gry> ().plik = zapis;//przypisuje ciąg znaków
			panel.GetComponent<wczytywanie_gry> ().wczytywanie ();//uruchamia funkcję
			Destroy (gameObject);//niszczy obiekt
		}
	}
}
