using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class nazwa : MonoBehaviour {
	public GameObject przycisk;//przechowuje dane obiektu
	private string zapis;//przechowuje ciąg zanaków

	void Update () {
		zapis = przycisk.GetComponent<lokalizacja_zapisu> ().zapis; //przypisuje siąg znaków
	    if (File.Exists(zapis)) {
			gameObject.GetComponent<Text>().text=""+File.GetLastWriteTime(zapis); //przypisuje siąg znaków
				}
		else {
			gameObject.GetComponent<Text>().text="Wolny zapis";//przypisuje siąg znaków
				}
	}
}
