using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class skład_armi : MonoBehaviour {
	private List<GameObject> lista_grupy;//przechowuje liste danych obiektów
	public List<GameObject> lista_wojowników_w_odziale;//przechowuje liste danych obiektów
	public int ilość_wojowników=0;//przechowuja wartość liczbową naturalną
	public List<GameObject> lista_uzdrowicieli_w_oddziale;//przechowuje liste danych obiektów
	public int ilość_uzdrowicieli=0;//przechowuja wartość liczbową naturalną

	void Update () {
		lista_grupy = new List<GameObject> (GameObject.Find ("Zarządzanie grupa " + gameObject.GetComponent<przynależność> ().Grupa).GetComponent<Jednostki_przynalerzne_do_grupy> ().lista_jednostek_grupy);//znajduje i przypisuje obieków
		if (lista_grupy.Count!=0) {
			if (lista_grupy.Contains(null)) {
				lista_grupy.Remove(null);//usuwa obiekt z listy
			}
		     foreach (var item in lista_grupy) {

				if (item.GetComponent<przynależność>().Nr_oddziału==gameObject.GetComponent<przynależność>().Nr_oddziału) {
					if (item.name.Contains("wojownik")) {
						if (!lista_wojowników_w_odziale.Contains(item)) {
							lista_wojowników_w_odziale.Add(item);//dodaje obiekt do listy
						}
					}
					if (item.name.Contains("uzdrowiciel")) {
						if (!lista_uzdrowicieli_w_oddziale.Contains(item)) {
							lista_uzdrowicieli_w_oddziale.Add(item);//dodaje obiekt do listy
						}
					}
				}

		     }
			ilość_wojowników=lista_wojowników_w_odziale.Count;//przypisuje wartość
			ilość_uzdrowicieli=lista_uzdrowicieli_w_oddziale.Count;//przypisuje wartość
				}
	}
}
