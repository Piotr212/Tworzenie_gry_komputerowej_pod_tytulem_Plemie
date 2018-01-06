using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Surowce : MonoBehaviour {
	public Text surowiec;//przechowuje obiekt UI text
	public int ilość=300;//przechowuja wartość liczbową naturalną

	void Update () {
		surowiec.text = ilość.ToString();//przypisuje ciąg znaków
	}
}
