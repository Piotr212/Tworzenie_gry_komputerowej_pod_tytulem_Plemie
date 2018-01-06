using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jednostki_przynalerzne_do_grupy : MonoBehaviour {
	public int grupa;//przechowuje numer grupy
	private List<GameObject> lista_jednostek;//przechowuje listę danych obiektów
	public List<GameObject> lista_jednostek_grupy;//przechowuje listę danych obiektów
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Unit")!=null) {
			lista_jednostek = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Unit"));//przypisuje liste obiektów
				}
		if (lista_jednostek.Count!=0) {
			foreach (var item in lista_jednostek) {
				if (item!=null) {
				if (item.GetComponent<przynależność>().Grupa==grupa) {
					if (!lista_jednostek_grupy.Contains(item)) {
						lista_jednostek_grupy.Add (item);//przypisuje liste obiektów
					}
					else {
						if (lista_jednostek_grupy.Count!=0) {
							if (item.GetComponent<Życie>().śmierć) {
								lista_jednostek_grupy.Remove(item);//usuwanie lementu z listy
							}
						}

					}
				}
			}
			}
				}
		lista_jednostek.Clear ();//czyszczenie listy
	}
}
