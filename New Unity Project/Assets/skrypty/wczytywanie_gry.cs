using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

public class wczytywanie_gry : MonoBehaviour {
	public string plik;//przechowuje ciąg znaków
	private string _dane;//przechowuje ciąg znaków
	public GameObject pomocne_wczytywanie;//przechowuje dane obiektu
	private GameObject pomocne_wczytywanie1;//przechowuje dane obiektu
	public GameObject wojownik;//przechowuje dane obiektu
	public GameObject drzewo;//przechowuje dane obiektu
	public GameObject robotnik;//przechowuje dane obiektu
	public GameObject uzdrowiciel;//przechowuje dane obiektu
	public GameObject chata;//przechowuje dane obiektu
    klasa_do_zapisu _klasa_do_zapisu;//odnośnik do skryptu
	
	void Start () {
		plik = null;//czyszczenie
	}
	
	public void wczytywanie()
	{
		if (plik != null) {
						odczyt_z_XML ();//aktywacja funkcji
						_klasa_do_zapisu = (klasa_do_zapisu)deserializacja (_dane);//przypisanie danych
						if (Application.loadedLevelName != _klasa_do_zapisu.nazwa_sceny) {
				             pomocne_wczytywanie1=(GameObject)Instantiate(pomocne_wczytywanie);//tworzy obiekt
				pomocne_wczytywanie1.GetComponent<wczytywanie_z_innej_sceny>().zapis=plik;//przypisanie ciągu znaków
				        DontDestroyOnLoad(pomocne_wczytywanie1);//uniemożliwia zniszczenie obiektu przy przejściu do następnej sceny
								Application.LoadLevel (_klasa_do_zapisu.nazwa_sceny);//przechodzi do wybranej sceny
						} 
			else {
				GameObject _UI =GameObject.Find("UI panel");//przechowuje dane obiektu
				_UI.GetComponent<zadania>().enabled=false;//wyłącza skrypt
				_UI.GetComponent<zadania>().cele_do_zniszczenia.Clear();//czyści listę
				if (GameObject.FindGameObjectWithTag ("Unit")) {
								List<GameObject> lista = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Unit"));//przechowuje znalezioną listę obiektów
								foreach (var item in lista) {
										Destroy (item);//niszczy obiekt
								}
						}
						if (GameObject.FindGameObjectWithTag ("drzewo")) {
					List<GameObject> lista = new List<GameObject> (GameObject.FindGameObjectsWithTag ("drzewo"));//przechowuje znalezioną listę obiektó
								foreach (var item in lista) {
						                 Destroy (item);//niszczy obiekt
								}
						}
				if (GameObject.FindGameObjectWithTag("Czepion")) {
					List<GameObject> lista = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Czepion"));//przechowuje znalezioną listę obiektó
					foreach (var item in lista) {
						Destroy (item);//niszczy obiekt
					}
				}
				if (GameObject.FindGameObjectWithTag("chata")) {
					List<GameObject> lista = new List<GameObject> (GameObject.FindGameObjectsWithTag ("chata"));//przechowuje znalezioną listę obiektó
					foreach (var item in lista) {
						Destroy (item);//niszczy obiekt
					}
				}
				GameObject.Find ("GameMaster").GetComponent<nadawanie_celu>().lista_w_oddziale.Clear();
				foreach (var item in _klasa_do_zapisu.drzewa) {
					GameObject _obiekt;//przechowuje dane obiektu
					_obiekt = (GameObject)Instantiate (drzewo,new Vector3 (item.położenie_x, item.położenie_y, item.położenie_z),drzewo.transform.rotation);//tworzy obiekt w przestrzeni
					_obiekt.GetComponent<Surowce> ().ilość =item.ilość;//przypisuje wartość
				}
				foreach (var item in _klasa_do_zapisu.chata) {
					GameObject _obiekt;//przechowuje dane obiektu
					_obiekt = (GameObject)Instantiate (chata,new Vector3 (item.położenie_x, item.położenie_y, item.położenie_z),new Quaternion(item.rotacja_x,item.rotacja_y,item.rotacja_z,item.rotacja_w) );//tworzy obiekt w przestrzeni
					_obiekt.GetComponent<przynależność> ().Grupa = item.grupa;//przypisuje wartość
					_obiekt.GetComponent<przynależność> ().Nr_oddziału = item.nr_oddziału;//przypisuje wartość
					_obiekt.GetComponent<Życie> ().currentHealth = item.stan_życia;//przypisuje wartość
					foreach (var item1 in item.kolejka) {
						if (item1=="wojownik") {
							_obiekt.GetComponent<produkcja>().kolejka.Add(wojownik);//dodaje obiekt do listy
						}
						if (item1=="uzdrowiciel") {
							_obiekt.GetComponent<produkcja>().kolejka.Add(uzdrowiciel);//dodaje obiekt do listy
						}
						if (item1=="robotnik") {
							_obiekt.GetComponent<produkcja>().kolejka.Add(robotnik);//dodaje obiekt do listy
						}
					}
					_obiekt.GetComponent<produkcja>().pasek_produkcji.value=item.czas;//przypisuje wartość
				}
				if (GameObject.Find("Postac")) {
					klasa_do_zapisu.dane_postaci wczytywany_obiekt = _klasa_do_zapisu.postaci;
					GameObject.Find ("Postac").transform.position = new Vector3 (wczytywany_obiekt.położenie_x, wczytywany_obiekt.położenie_y, wczytywany_obiekt.położenie_z);//przypisuje wartość
					GameObject.Find ("Postac").GetComponent<przynależność> ().Grupa = wczytywany_obiekt.grupa;//przypisuje wartość
					GameObject.Find ("Postac").GetComponent<przynależność> ().Nr_oddziału = wczytywany_obiekt.nr_oddziału;//przypisuje wartość
					GameObject.Find ("Postac").GetComponent<Życie> ().currentHealth=wczytywany_obiekt.stan_życia;//przypisuje wartość
					GameObject.Find ("Postac").GetComponent<mana> ().stan_many = wczytywany_obiekt.stan_many;//przypisuje wartość
				}
				foreach (var item in _klasa_do_zapisu.wojownik) {
					GameObject _obiekt;//przechowuje dane obiektu
					_obiekt = (GameObject)Instantiate (wojownik,new Vector3 (item.położenie_x, item.położenie_y, item.położenie_z),wojownik.transform.rotation);//tworzy obiekt w przestrzeni

					_obiekt.GetComponent<przynależność> ().Grupa = item.grupa;//przypisuje wartość
					_obiekt.GetComponent<przynależność> ().Nr_oddziału = item.nr_oddziału;//przypisuje wartość
					_obiekt.GetComponent<Życie> ().currentHealth = item.stan_życia;//przypisuje wartość
					_obiekt.GetComponent<AI_wojownika> ().nowy_cel = (item.nowy_cel == "true");//przypisuje wartość
					_obiekt.GetComponent<AI_wojownika> ().cel = new Vector3 (item.cel_x, item.cel_y, item.cel_z);//przypisuje wartość
				}
				foreach (var item in _klasa_do_zapisu.uzdrowiciel) {
					GameObject _obiekt;//przechowuje dane obiektu
					_obiekt = (GameObject)Instantiate (uzdrowiciel,new Vector3 (item.położenie_x, item.położenie_y, item.położenie_z),uzdrowiciel.transform.rotation);//tworzy obiekt w przestrzeni
					_obiekt.GetComponent<przynależność> ().Grupa = item.grupa;//przypisuje wartość
					_obiekt.GetComponent<przynależność> ().Nr_oddziału = item.nr_oddziału;//przypisuje wartość
					_obiekt.GetComponent<Życie> ().currentHealth = item.stan_życia;//przypisuje wartość
					_obiekt.GetComponent<mana>().stan_many=item.stan_many;//przypisuje wartość
					_obiekt.GetComponent<do_celu> ()._cel = new Vector3 (item.cel_x, item.cel_y, item.cel_z);//przypisuje wartość
					if (_obiekt.GetComponent<do_celu> ()._cel!=new Vector3(0,0,0)) {
						_obiekt.GetComponent<do_celu> ().Idź(_obiekt.GetComponent<do_celu> ()._cel);//przypisuje wartość
					}
				}
				foreach (var item in _klasa_do_zapisu.robotnik) {
					GameObject _obiekt;//przechowuje dane obiektu
					_obiekt = (GameObject)Instantiate (robotnik,new Vector3 (item.położenie_x, item.położenie_y, item.położenie_z),robotnik.transform.rotation);//tworzy obiekt w przestrzeni
					_obiekt.GetComponent<przynależność> ().Grupa = item.grupa;//przypisuje wartość
					_obiekt.GetComponent<przynależność> ().Nr_oddziału = item.nr_oddziału;//przypisuje wartość
					_obiekt.GetComponent<Życie> ().currentHealth = item.stan_życia;//przypisuje wartość
					_obiekt.GetComponent<zbieranie_sórowców> ().niesiony = item.ilość;//przypisuje wartość
				}

				GameObject.Find ("GameMaster").GetComponent<Surowce> ().ilość = _klasa_do_zapisu.GameMaster.ilość;//przypisuje wartość
				foreach (var item in _klasa_do_zapisu.zadania) {
					Vector3 położenie=new Vector3(item.położenie_x,item.położenie_y,item.położenie_z);//tworzy punkt w przestrzeni
					List<GameObject>szukanie=new List<GameObject>(GameObject.FindGameObjectsWithTag(item.tag));//tworzy liste obiektów
					foreach (var item1 in szukanie) {
						if (item1.transform.position==położenie) {
							_UI.GetComponent<zadania>().cele_do_zniszczenia.Add(item1);//dodaje do listy
						}
					}
				}
				_UI.GetComponent<zadania>().enabled=true;
				Time.timeScale=1;//zmiana prędkości
						plik = null;//czyszczenie
				}
				}
		}
	void odczyt_z_XML()
	{
		StreamReader reader= File.OpenText(plik);//odczytuje zawartośc pliku
		string zawartość_pliku = reader.ReadToEnd();//przypisuje ciąg znaków z pliku
		reader.Close ();//wyłączenie
		_dane = zawartość_pliku;//przypisuje ciąg znaków
		}
	object deserializacja(string dane)
	{
		XmlSerializer serializerxml = new XmlSerializer (typeof( klasa_do_zapisu ));//przypisuje wzór zapisu
		MemoryStream pamięć = new MemoryStream (do_tablicy(dane));//przypisuje dane
		XmlTextWriter writer = new XmlTextWriter (pamięć, Encoding.UTF8);//przetwarza dane
		return serializerxml.Deserialize (pamięć);//zwraca przetworzone dane
		}
	byte[] do_tablicy(string dane)
	{
		UTF8Encoding kodowanie = new UTF8Encoding ();//kodowane znaków
		byte[] tablica = kodowanie.GetBytes (dane);//przypisuje dane do tablicy
		return tablica;//zwraca tablicę
	}
}
