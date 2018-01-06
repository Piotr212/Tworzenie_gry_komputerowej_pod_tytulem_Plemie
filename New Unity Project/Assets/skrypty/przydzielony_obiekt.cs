using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class przydzielony_obiekt : MonoBehaviour {
	public GameObject panel_główny;//przechowuja dane obiektu
	public GameObject panel;//przechowuja dane obiektu
	public GameObject panel1;//przechowuja dane obiektu
	public GameObject obiekt;//przechowuja dane obiektu
	public Text nazwa;//przechowuja dane obiektu UI Text

	public void przydzielenie()
	{
		if (panel_główny.GetComponent<wybór_oddziału> ().pochodzenie ==null) {
			panel_główny.GetComponent<wybór_oddziału> ().pochodzenie = obiekt;//przydzielanie obiektu
				}
		else {
			panel_główny.GetComponent<wybór_oddziału> ().przeniesienie_do=obiekt;//przydzielanie obiektu
				}

		panel.SetActive (false);//desaktywacja obiektu
		panel1.SetActive (true);//aktywacja obiektu
		}

	void Update () {
		nazwa.GetComponent<Text> ().text = obiekt.name;
		panel_główny = GameObject.Find ("Panel zarządzania armią");//znajdywanie i przydzielanie obiektu
		panel = panel_główny.GetComponent<oddziały> ().panel;//przydzielanie obiektu
		panel1= panel_główny.GetComponent<oddziały> ().panel1;//przydzielanie obiektu
		if (panel_główny.GetComponent<wybór_oddziału>().pochodzenie==obiekt) {
			gameObject.SetActive(false);//desaktywacja obiektu
				}

	}
}
