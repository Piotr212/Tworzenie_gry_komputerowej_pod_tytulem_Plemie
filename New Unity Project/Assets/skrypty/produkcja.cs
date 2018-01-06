using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class produkcja : MonoBehaviour {
	public List<GameObject> kolejka = new List<GameObject>();//przechowuje liste danych obiektów
	przynależność jest;//odnośnik do skryptu
	przynależność jednostka_przynalerzy;//odnośnik do skryptu
	public GameObject punkt_pojawienia;//przechowuje liste danych obiektów
	public Slider pasek_produkcji;//przechowuje obiekt UI slider
	void Start () {
		jest = GetComponent<przynależność>();//przypisuje skrypt

	}

	
	// Update is called once per frame
	void Update () {

		if (kolejka.Count!=0) {
			if (pasek_produkcji.value<pasek_produkcji.maxValue) {
				pasek_produkcji.value+=Time.deltaTime;//nalicza czas
			}
			if (pasek_produkcji.value==pasek_produkcji.maxValue) {
				jednostka_przynalerzy=kolejka[0].GetComponent<przynależność>();//przypisuje skrypt
				jednostka_przynalerzy.Grupa=jest.Grupa;//przypisuje wartość
				jednostka_przynalerzy.Nr_oddziału=jest.Nr_oddziału;//przypisuje wartość
				Instantiate(kolejka[0],punkt_pojawienia.transform.position,punkt_pojawienia.transform.rotation);//umieszcza obiekt w przestrzeni
				kolejka.RemoveAt(0);//usuwa obiekt z listy
				pasek_produkcji.value=0;//zeruje naliczanie
			}

				}
			
				

	}
}
