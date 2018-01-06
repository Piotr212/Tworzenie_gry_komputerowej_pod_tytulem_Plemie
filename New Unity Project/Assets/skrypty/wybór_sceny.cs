using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class wybór_sceny : MonoBehaviour {

	public string nazwa_sceny;
	public GameObject przycisk;//przechowuje dane obiektu
	public Text panel_opisu;//przechowuje dane obiektu UI text
	public List<string> treść=new List<string>();//tworzy liste ciągów znaków

	public void wybór()
	{
		przycisk.GetComponent<do_sceny> ().nazwa_sceny = nazwa_sceny;//przypisane ciągu znaków
		panel_opisu.text = "";//czyści pole text
		foreach (var item in treść) {
			panel_opisu.text+=item+"\n";//dodaje ciąg znaków
				}
	}
}
