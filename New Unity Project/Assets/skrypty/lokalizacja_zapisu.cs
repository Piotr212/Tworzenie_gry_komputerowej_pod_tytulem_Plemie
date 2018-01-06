using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class lokalizacja_zapisu : MonoBehaviour {
	public string nazwa_zapisu;//przechowuje ciąg znaków
	public GameObject panel;//przechowuje dane obiektu
	public string zapis;//przechowuje ciąg znaków
	void Update ()
	{
		zapis=Application.dataPath+"\\zapisy\\"+nazwa_zapisu+".xml";//przypisuje ciąg znaków
		if (panel.name != "Panel zapisu") {
						if (File.Exists (zapis)) {
				gameObject.GetComponent<Button>().interactable=true;//aktywuje przycisk
						}
			else {
				gameObject.GetComponent<Button>().interactable=false;//desaktywuje przycisk
			}
				}
		}
    public void podaj()
	{
		if (panel.name=="Panel zapisu") {
			panel.GetComponent<Zapis_gry> ().lokalizacja_zapisu = zapis;//przechowuje ciąg znaków
				}
		else {
			panel.GetComponent<wczytywanie_gry>().plik = zapis;//przechowuje ciąg znaków
				}

	}
}
