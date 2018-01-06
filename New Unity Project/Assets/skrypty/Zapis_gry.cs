using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
public class Zapis_gry : MonoBehaviour {
	public string lokalizacja_zapisu;//przechowuje ciąg znaków
	private string dane_do_string;//przechowuje ciąg znaków

	void Start () {
		lokalizacja_zapisu = null;//usuwanie zawartości

	}
	
	public void zapis()
	{
		if (lokalizacja_zapisu != null) {
			GameObject gamemaster = GameObject.Find ("GameMaster");//przechowuje dane obiektu
			GameObject postać = GameObject.FindGameObjectWithTag ("Gracz");//przechowuje dane obiektu
			List<GameObject> wojownik = new List<GameObject>();//przechowuje liste danych obiektów
			List<GameObject> uzdrowiciel = new List<GameObject>();//przechowuje liste danych obiektów
			List<GameObject> robotnik =new List<GameObject>() ;//przechowuje liste danych obiektów
			List<GameObject> jednostki = new List<GameObject>(GameObject.FindGameObjectsWithTag("Unit"));//przechowuje znalezioną listę obiektó
			if (GameObject.FindGameObjectWithTag("Czepion")) {
				List<GameObject> czepioni=new List<GameObject>(GameObject.FindGameObjectsWithTag("Czepion"));//przechowuje znalezioną listę obiektó
			foreach (var item in czepioni) {
				jednostki.Add(item);//dodawanie obiektu do listy
			}
			}
			foreach (var item in jednostki) {
				if (item.name.Contains("wojownik")) {
					wojownik.Add(item);//dodawanie obiektu do listy
				}
				if (item.name.Contains("uzdrowiciel")) {
					uzdrowiciel.Add(item);//dodawanie obiektu do listy
				}
				if (item.name.Contains("robotnik")) {
					robotnik.Add(item);//dodawanie obiektu do listy
				}
			}
			   
						
			List<GameObject> drzewa =new List<GameObject>(GameObject.FindGameObjectsWithTag ("drzewo"));//przechowuje znalezioną listę obiektó
			List<GameObject> chaty=new List<GameObject>(GameObject.FindGameObjectsWithTag ("chata"));//przechowuje znalezioną listę obiektó
			klasa_do_zapisu _obiekt = new klasa_do_zapisu ();//odnośnik do skryptu
						_obiekt.nazwa_sceny = Application.loadedLevelName;//przypisanie ciągu znaków
			klasa_do_zapisu.dane_postaci dane_postaci=new klasa_do_zapisu.dane_postaci();//przechowuje strukture
			dane_postaci.położenie_x=postać.transform.position.x;//przypisuje wartość
			dane_postaci.położenie_y=postać.transform.position.y;//przypisuje wartość
			dane_postaci.położenie_z=postać.transform.position.z;//przypisuje wartość
			dane_postaci.grupa=postać.GetComponent<przynależność> ().Grupa;//przypisuje wartość
			dane_postaci.nr_oddziału=postać.GetComponent<przynależność> ().Nr_oddziału;//przypisuje wartość
			dane_postaci.stan_życia=postać.GetComponent<Życie> ().currentHealth;//przypisuje wartość
			dane_postaci.stan_many=postać.GetComponent<mana>().stan_many;//przypisuje wartość
			_obiekt.postaci=dane_postaci;//przypisanie struktury
			foreach (var item in wojownik) {
				klasa_do_zapisu.dane_wojownika dane = new klasa_do_zapisu.dane_wojownika ();//przechowuje strukture
				dane.tag=item.tag;//przypisanie ciągu znaków
				dane.położenie_x = item.transform.position.x;//przypisuje wartość
				dane.położenie_y = item.transform.position.y;//przypisuje wartość
				dane.położenie_z = item.transform.position.z;//przypisuje wartość
				dane.grupa = item.GetComponent<przynależność> ().Grupa;//przypisuje wartość
				dane.nr_oddziału = item.GetComponent<przynależność> ().Nr_oddziału;//przypisuje wartość
				dane.stan_życia = item.GetComponent<Życie> ().currentHealth;//przypisuje wartość
				dane.nowy_cel = item.GetComponent<AI_wojownika> ().nowy_cel.ToString ();
				dane.cel_x = item.GetComponent<AI_wojownika> ().cel.x;//przypisuje wartość
				dane.cel_y = item.GetComponent<AI_wojownika> ().cel.y;//przypisuje wartość
				dane.cel_z = item.GetComponent<AI_wojownika> ().cel.z;//przypisuje wartość
				_obiekt.wojownik.Add(dane);//dodaje syrukture do listy
			}
			foreach (var item in uzdrowiciel) {
				klasa_do_zapisu.dane_uzdrowiciela dane = new klasa_do_zapisu.dane_uzdrowiciela ();//przechowuje strukture
				dane.tag=item.tag;//przypisanie ciągu znaków
				dane.położenie_x = item.transform.position.x;//przypisuje wartość
				dane.położenie_y = item.transform.position.y;//przypisuje wartość
				dane.położenie_z = item.transform.position.z;//przypisuje wartość
				dane.grupa = item.GetComponent<przynależność> ().Grupa;//przypisuje wartość
				dane.nr_oddziału = item.GetComponent<przynależność> ().Nr_oddziału;//przypisuje wartość
				dane.stan_życia = item.GetComponent<Życie> ().currentHealth;//przypisuje wartość
				dane.cel_x = item.GetComponent<do_celu> ()._cel.x;//przypisuje wartość
				dane.cel_y = item.GetComponent<do_celu> ()._cel.y;//przypisuje wartość
				dane.cel_z = item.GetComponent<do_celu> ()._cel.z;//przypisuje wartość
				_obiekt.uzdrowiciel.Add(dane);//dodaje syrukture do listy
			}
			foreach (var item in robotnik) {
				klasa_do_zapisu.dane_robotnik dane = new klasa_do_zapisu.dane_robotnik ();//przechowuje strukture
				dane.położenie_x = item.transform.position.x;//przypisuje wartość
				dane.położenie_y = item.transform.position.y;//przypisuje wartość
				dane.położenie_z = item.transform.position.z;//przypisuje wartość
				dane.grupa = item.GetComponent<przynależność> ().Grupa;//przypisuje wartość
				dane.nr_oddziału = item.GetComponent<przynależność> ().Nr_oddziału;//przypisuje wartość
				dane.stan_życia = item.GetComponent<Życie> ().currentHealth;//przypisuje wartość
				dane.ilość=item.GetComponent<zbieranie_sórowców>().niesiony;//przypisuje wartość
				_obiekt.robotnik.Add(dane);//dodaje syrukture do listy
			}
			foreach (var item in chaty) {
				klasa_do_zapisu.dane_chat dane = new klasa_do_zapisu.dane_chat ();//przechowuje strukture
				dane.położenie_x = item.transform.position.x;//przypisuje wartość
				dane.położenie_y = item.transform.position.y;//przypisuje wartość
				dane.położenie_z = item.transform.position.z;//przypisuje wartość
				dane.rotacja_x=item.transform.rotation.x;//przypisuje wartość
				dane.rotacja_y=item.transform.rotation.y;//przypisuje wartość
				dane.rotacja_z=item.transform.rotation.z;//przypisuje wartość
				dane.rotacja_w=item.transform.rotation.w;//przypisuje wartość
				dane.grupa = item.GetComponent<przynależność> ().Grupa;//przypisuje wartość
				dane.nr_oddziału = item.GetComponent<przynależność> ().Nr_oddziału;//przypisuje wartość
				dane.stan_życia = item.GetComponent<Życie> ().currentHealth;//przypisuje wartość
				foreach (var item1 in item.GetComponent<produkcja>().kolejka) {
					dane.kolejka.Add(item1.name);//dodaje ciągu znaków do listy
				}

				dane.czas=item.GetComponent<produkcja>().pasek_produkcji.value;//przypisuje wartość
				_obiekt.chata.Add(dane);//dodaje syrukture do listy
			}
			foreach (var item in drzewa) {
				klasa_do_zapisu.dane_drzew dane = new klasa_do_zapisu.dane_drzew();//przechowuje strukture
				dane.położenie_x = item.transform.position.x;//przypisuje wartość
				dane.położenie_y = item.transform.position.y;//przypisuje wartość
				dane.położenie_z = item.transform.position.z;//przypisuje wartość
				dane.ilość=item.GetComponent<Surowce>().ilość;//przypisuje wartość
				_obiekt.drzewa.Add(dane);//dodaje syrukture do listy
			}
			GameObject _UI =GameObject.Find("UI panel");//przechowuje dane obiektu
			foreach (var item in _UI.GetComponent<zadania>().cele_do_zniszczenia) {
				klasa_do_zapisu.dane_zadań dane=new klasa_do_zapisu.dane_zadań();//przechowuje strukture
				dane.tag=item.tag;//przypisanie ciągu znaków
				dane.położenie_x=item.transform.position.x;//przypisuje wartość
				dane.położenie_y=item.transform.position.y;//przypisuje wartość
				dane.położenie_z=item.transform.position.z;//przypisuje wartość
				_obiekt.zadania.Add(dane);//dodaje syrukture do listy
			}
			klasa_do_zapisu.dane_GameMaster dane_GM=new klasa_do_zapisu.dane_GameMaster();//przechowuje strukture
			dane_GM.ilość=gamemaster.GetComponent<Surowce>().ilość;//przypisuje wartość
			_obiekt.GameMaster=dane_GM;//przypisuje strukture
		      dane_do_string = serializacjaobiektów (_obiekt);//przypisanie ciągu znaków
				zapis_do_xml ();//aktywacja funkcji
						
			lokalizacja_zapisu=null;//usuwanie zawartości
		}
	}

	string serializacjaobiektów(object dane_obiektów)
	{
		string otrzymany_string = null;//przechowuje ciąg znaków
		MemoryStream pamięć = new MemoryStream ();//przechowuje pamięć
		XmlSerializer serializerxml = new XmlSerializer (typeof( klasa_do_zapisu ));//przypisuje wzór zapisu
		XmlTextWriter writer_xml = new XmlTextWriter (pamięć, Encoding.UTF8);//przetwarza dane
		serializerxml.Serialize (writer_xml, dane_obiektów);//koduje ciąg znaków
		pamięć = (MemoryStream)writer_xml.BaseStream;//przypisuje przetworzone dane
		otrzymany_string = do_stringa (pamięć.ToArray ());//przypisuje ciąg znaków
		return otrzymany_string;//zwraca string
	}

	string do_stringa(byte[] tablica)
	{
		UTF8Encoding kodowanie = new UTF8Encoding ();//kodowane znaków
		string otrzymany_string = kodowanie.GetString(tablica);//przypisuje dane do tablicy
		return otrzymany_string;//zwraca tablicę
	}
	void zapis_do_xml()
	{
		StreamWriter writer;//odnośnik do pliku tekstowego
		FileInfo info=new FileInfo(lokalizacja_zapisu);//przechowuje informacje o lokacji
		if (!info.Exists) {
			writer=info.CreateText();//tworzy plik textowy
		}
		else {
			info.Delete();//usuwa plik
			writer=info.CreateText();//tworzy plik textowy
		}
		writer.Write (dane_do_string);//wpisuje ciąg znaków do pliku
		writer.Close ();//wyłącza StreamWriter
	}
}