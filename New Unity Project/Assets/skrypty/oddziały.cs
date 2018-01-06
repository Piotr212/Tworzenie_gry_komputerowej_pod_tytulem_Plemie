using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class oddziały : MonoBehaviour {
	public Button przycisk;//przechowuje dane przycisku UI
	public Button przycisk1;//przechowuje dane przycisku UI
	public Button przycisk2;//przechowuje dane przycisku UI
	public bool jest=true;//przechowuje zmienną logiczną
	public GameObject panel;//przechowuje dane o obiekcie
	public GameObject panel1;//przechowuje dane o obiekcie
	private List<GameObject> lista_odziałów;//przechowuje listę danych o obiektach
	private List<Button>przyciski=new List<Button>();//przechowuje listę danych o przyciskach UI
	void Update () {
		lista_odziałów = new List<GameObject> (GameObject.Find ("Zarządzanie grupa 1").GetComponent<dowódctwo> ().czępion);//znajduje i przypisuje obiektu do listy

	
	}
	public void usuwanie_przycisków()
	{
		foreach (var item in przyciski) {
			Destroy(item);//niszczy obiekt
		}
		przyciski.Clear ();//czyćzi listę ze wczystkich obiektów
		jest = true;//przyypisuje wartość logiczną
		przycisk1 = null;//usuwa połączenie z obiektem 
		przycisk2 = null;//usuwa połączenie z obiektem
	}
	public void lista()
	{
		lista_odziałów = new List<GameObject> (GameObject.Find ("Zarządzanie grupa 1").GetComponent<dowódctwo> ().czępion);
		foreach (var item in lista_odziałów) {
			przycisk1=Instantiate(przycisk) as Button;//tworzy obiekt
			przycisk1.transform.parent=panel.transform;//parentuje obiekt
			przyciski.Add(przycisk1);
			if (jest) {

				przycisk1.GetComponent<RectTransform>().anchoredPosition=new Vector2(-125f,-59f);//ummieszcza obiekt UI w wybranej lokacji
				jest=false;//przyypisuje wartość logiczną
			}
			else {
				przycisk1.GetComponent<RectTransform>().anchoredPosition=new Vector2(przycisk2.GetComponent<RectTransform>().anchoredPosition.x,przycisk2.GetComponent<RectTransform>().anchoredPosition.y-33f);//ummieszcza obiekt UI w wybranej lokacji
			}
			przycisk1.GetComponent<przydzielony_obiekt>().obiekt=item;//przypisuje obiekt
			przycisk2=przycisk1;//przypisuje obiekt
				}
		}
}
