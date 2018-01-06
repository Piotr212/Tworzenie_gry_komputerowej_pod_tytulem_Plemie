using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class zadania : MonoBehaviour {
	public bool czy_do_celu;//przechowuje zmienną logiczną 
	private bool do_celu_wykonane=false;//przechowuje zmienną logiczną 
	public GameObject dotrzeć_do;//przechowuje dane obiektu
	public bool czy_zniszcz_cel;//przechowuje zmienną logiczną 
	private bool zniszczone_cele_wykonanie=false;//przechowuje zmienną logiczną 
	public List<GameObject>cele_do_zniszczenia = new List<GameObject> ();//przechowuje liste danych obiektów
	public List<bool> warunki_zwycięstwa=new List<bool>();//przechowuje liste zmiennych logicznych
	private int zliczanie_wykonanych_zadań=0;//przechowuja wartość liczbową naturalną
	public bool czy_przeżyć;//przechowuje zmienną logiczną 
	public GameObject ma_przeżyć;//przechowuje dane obiektu
	public Text panel_zadań;//przechowuje dane obiektu UI Text
	private string treść_zadań;//przechowyje ciąg znaków


	void Update () {
		treść_zadań = "Zadania:\n";//przypisanie ciągu znaków
		if (czy_do_celu) {
			treść_zadań+="Dojdź do "+dotrzeć_do.name+"\n";//dodawanie ciągu znaków
			if (dotrzeć_do.GetComponent<u_celu>().jest) {
				do_celu_wykonane=true;//przypisanie wartości logicznej

			}
			warunki_zwycięstwa.Add(do_celu_wykonane);//dodawanie wartości logicznej
				}
		if (czy_zniszcz_cel) {
			treść_zadań+="Zniszcz "+cele_do_zniszczenia.Count+" chaty \n";//dodawanie ciągu znaków
			if (cele_do_zniszczenia.Contains(null)) {
				cele_do_zniszczenia.Remove(null);//usuwanie z listy
			}
			if (cele_do_zniszczenia.Count==0) {
				zniszczone_cele_wykonanie=true;//przypisanie wartości logicznej
			}
			warunki_zwycięstwa.Add(zniszczone_cele_wykonanie);//dodawanie wartości logicznej
				}
		foreach (var item in warunki_zwycięstwa) {
			if (item) {
				zliczanie_wykonanych_zadań+=1;//dodawanie wartości
			}
				}
		if (zliczanie_wykonanych_zadań==warunki_zwycięstwa.Count) {
			Application.LoadLevel("Zwysięstwo");//przejście do wybranej sceny
				}
		zliczanie_wykonanych_zadań = 0;//zerowanie
		warunki_zwycięstwa.Clear ();//czyszczenie listy
		if (czy_przeżyć) {
			treść_zadań+=ma_przeżyć.name+" ma przeżyć";//dodawanie ciągu znaków
			if (ma_przeżyć.GetComponent<Życie>().śmierć) {
				Application.LoadLevel("Porażka");//przejście do wybranej sceny
			}
				}
		panel_zadań.text = treść_zadań;//przypisanie ciągu znaków
		treść_zadań = "";//przypisanie ciągu znaków


	
	}
}
