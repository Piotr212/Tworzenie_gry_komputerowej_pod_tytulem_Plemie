using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class dodanie_do_produkcji : MonoBehaviour {

	public GameObject chata;//przechowuje dane obiektu
	public GameObject jednostka_do_produkcji;//przechowuje dane obiektu
	public int koszt;//przechowuje wartość liczbową naturalną
	public void przycisk_produkcji()
	{
		if (GameObject.Find("GameMaster").GetComponent<Surowce>().ilość>=koszt) {
			chata.GetComponent<produkcja>().kolejka.Add(jednostka_do_produkcji);//dodaje element do listy
			GameObject.Find("GameMaster").GetComponent<Surowce>().ilość-=koszt;//odejmuje ilość zasobów 
			
		}
	}
}
