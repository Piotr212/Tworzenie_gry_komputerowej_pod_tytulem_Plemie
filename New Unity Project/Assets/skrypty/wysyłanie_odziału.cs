using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class wysyłanie_odziału : MonoBehaviour {
	public List<GameObject> lista_puktów_pojawienia=new List<GameObject>();//przechowuje liste danych obiektów
	private List<GameObject>skład_odziału=new List<GameObject>();//przechowuje liste danych obiektów
	public GameObject prefabrykant_wojownika;//przechowuje dane obiektu
	public GameObject prefabrykant_uzdrowiciela;//przechowuje dane obiektu
	public float czas_do_wysłania;//przechowuje wartość liczbową rzeczywistą
	private float miniony_czas=0f;//przechowuje wartość liczbową rzeczywistą
	public int ilość_wojowników;//przechowuja wartość liczbową naturalną
	public int ilość_uzdrowicieli;//przechowuja wartość liczbową naturalną
	private int ilość_wojowników_potrzebna_do_zwiększenia_liczby_uzdrowicieli=5;//przechowuja wartość liczbową naturalną
	private int wybrany_punkt_pojawienia=0;//przechowuja wartość liczbową naturalną
	public GameObject cel;//przechowuje dane obiektu
	private int przydział_do_grupy;//przechowuja wartość liczbową naturalną
	private int przydział_do_odziału=0;//przechowuja wartość liczbową naturalną
	void Start () {
		przydział_do_grupy=GetComponent<Jednostki_przynalerzne_do_grupy>().grupa;//przypisanie wartości
	}
	

	void Update () {
				miniony_czas += Time.deltaTime;//naliczanie
				if (miniony_czas > czas_do_wysłania) {
						miniony_czas = 0f;//zerowanie
						if (wybrany_punkt_pojawienia == lista_puktów_pojawienia.Count - 1) {
				                wybrany_punkt_pojawienia = 0;//przypisanie wartości
						} else {
								wybrany_punkt_pojawienia += 1;//dodanie wartości
						}
			przydział_do_grupy = GetComponent<Jednostki_przynalerzne_do_grupy> ().grupa;//przypisanie wartości
						        ilość_wojowników += 1;
						if (ilość_wojowników == ilość_wojowników_potrzebna_do_zwiększenia_liczby_uzdrowicieli) {
				ilość_uzdrowicieli += 1;//dodanie wartości
								ilość_wojowników_potrzebna_do_zwiększenia_liczby_uzdrowicieli *= 2;//mnorzenie wartości
						}
						for (int i = 0; i < ilość_wojowników; i++) {
								GameObject produkowany = (GameObject)Instantiate (prefabrykant_wojownika, lista_puktów_pojawienia [wybrany_punkt_pojawienia].transform.position, lista_puktów_pojawienia [wybrany_punkt_pojawienia].transform.rotation);//tworzenie obiektu w przestrzeni
				produkowany.GetComponent<przynależność> ().Grupa = przydział_do_grupy;//przypisanie wartości
				produkowany.GetComponent<przynależność> ().Nr_oddziału = przydział_do_odziału;//przypisanie wartości
								skład_odziału.Add (produkowany);//dodanie do listy
						}
						if (ilość_uzdrowicieli > 0) {
								for (int i = 0; i < ilość_uzdrowicieli; i++) {
					GameObject produkowany = (GameObject)Instantiate (prefabrykant_uzdrowiciela, lista_puktów_pojawienia [wybrany_punkt_pojawienia].transform.position, lista_puktów_pojawienia [wybrany_punkt_pojawienia].transform.rotation);//tworzenie obiektu w przestrzeni
					produkowany.GetComponent<przynależność> ().Grupa = przydział_do_grupy;//przypisanie wartości
					produkowany.GetComponent<przynależność> ().Nr_oddziału = przydział_do_odziału;//przypisanie wartości
					skład_odziału.Add (produkowany);//dodanie do listy
								}
						}
						skład_odziału [0].tag = "Czepion";//zmiana tagu obiektu

				}
		if (GameObject.FindGameObjectWithTag ("Czepion")) {
				GameObject czępion = GameObject.FindGameObjectWithTag ("Czepion");//odnajduje i przypisuje obiekt
				if (skład_odziału.Count != 0) {
						if (czępion.name != "uzdrowiciel") {
								czępion.GetComponent<AI_wojownika> ().nowy_cel = true;//ptzypisanie wartości logicznej
								czępion.GetComponent<AI_wojownika> ().cel = cel.transform.position;//przypisanie pozycji w przestrzeni
						} else {
								czępion.GetComponent<AI_uzdrowiciela> ()._do_celu.Idź (cel.transform.position);//uruchomienie funkcji
						}
						if (czępion.GetComponent<Życie> ().śmierć) {
								skład_odziału.RemoveAt (0);//usuwanie obiektu z listy
					skład_odziału [0].tag = "Czepion";//zmiana tagu obiektu
						}
						for (int i = 1; i < skład_odziału.Count; i++) {
								if (skład_odziału [i].name == "wojownik") {
										skład_odziału [i].GetComponent<AI_wojownika> ().czępion = skład_odziału [0];//przypisanie obiektu
								}
								if (skład_odziału [i].name == "uzdrowiciel") {
						skład_odziału [i].GetComponent<AI_uzdrowiciela> ().czępion = skład_odziału [0];//przypisanie obiektu
								}
						}
			}
		}
	}
}
