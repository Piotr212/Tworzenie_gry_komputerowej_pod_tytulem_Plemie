using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class obrona_obozu_SI : MonoBehaviour {
	public GameObject wojownik;//przechowuje dane o obiekcie w tym przypadku o prefabrykancie wojownik
	public int przydzielona_ilość_wojowników;//przechowuje wartość liczboą naturalną
	public float naliczanie_czasu;//przechowuje wartość liczboą rzeczywistą
	public float wymagany_czas;//przechowuje wartość liczboą rzeczywistą
	public GameObject punkt_pojawienia;//przechowuje dane o obiekcie

	void Update () {
		if (GetComponent<skład_armi>().lista_wojowników_w_odziale.Count<przydzielona_ilość_wojowników) {
			naliczanie_czasu+=Time.deltaTime; //nalicza czas
			if (naliczanie_czasu>wymagany_czas) {
				GameObject jednostka=(GameObject)Instantiate(wojownik,punkt_pojawienia.transform.position,punkt_pojawienia.transform.rotation);//tworzy obiekt w wskazanym piejscu
				przynależność jednostka_przynalerzy=jednostka.GetComponent<przynależność>();//przypisuje sktrpt
				jednostka_przynalerzy.Grupa=GetComponent<przynależność>().Grupa;//przypisuje wartość
				jednostka_przynalerzy.Nr_oddziału=GetComponent<przynależność>().Nr_oddziału;//przypisuje wartość
				naliczanie_czasu=0f;//zeruje
			}
				}
		else {
			naliczanie_czasu=0f;//zeruje
				}
	}
}
