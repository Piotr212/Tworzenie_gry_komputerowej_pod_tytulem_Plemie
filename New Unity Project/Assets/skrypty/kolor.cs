using UnityEngine;
using System.Collections;

public class kolor : MonoBehaviour {
	public Material[] kolory;//przechowuje tabele materiałów
	public GameObject obiekt;//przechowuje dane obiektu
	private przynależność należy;//przechowuje skrypt przynalerzność
	void Update () {
		kolory = GameObject.Find ("GameMaster").GetComponent<lista_kolorów> ().kolory;//pobiera matriały
		należy = GetComponent<przynależność> ();//przypisanie sktyptu
		obiekt.GetComponent<Renderer>().material= kolory [należy.Grupa];//przydziela kolor
	}
}
