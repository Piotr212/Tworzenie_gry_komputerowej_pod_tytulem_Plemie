using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class przypisywanie_ilości : MonoBehaviour {
	public GameObject panel_główny;//przechowuje dane obiektu
	private int ilość_jednostek=0;//przechowuja wartość liczbową naturalną
	public Text wyświetlacz_ilości;//przechowuje obiekt UI text
	public GameObject suwk;//przechowuje dane obiektu
	public Slider wartości;//przechowuje komponent
	public Text aktualnie_wybrana_ilość;//przechowuje obiekt UI text
	private List<GameObject> lista_przechodnia;//przechowuje liste danych obiektów
	public Button przycisk;//przechowuje obiekt UI button
	public string rodzaj_jednostki;//przechowuje ciąg znaków

	void Start () {
		wartości = suwk.GetComponent<Slider> ();//przypisuje komponent
	}
	public void wybór()
	{
		wartości.maxValue = ilość_jednostek;//przypisuje wartość
		}
	public void przenoszennie()
	{
		if (rodzaj_jednostki=="wojownik") {
			lista_przechodnia = new List<GameObject> (panel_główny.GetComponent<wybór_oddziału> ().pochodzenie.GetComponent<skład_armi> ().lista_wojowników_w_odziale);//przypisuje listę
				}
		if (rodzaj_jednostki=="uzdrowiciel") {
			lista_przechodnia = new List<GameObject> (panel_główny.GetComponent<wybór_oddziału> ().pochodzenie.GetComponent<skład_armi> ().lista_uzdrowicieli_w_oddziale);//przypisuje listę
		}

		for (int i = 0; i < wartości.value; i++) {
			lista_przechodnia[i].GetComponent<przynależność>().Nr_oddziału=panel_główny.GetComponent<wybór_oddziału>().przeniesienie_do.GetComponent<przynależność>().Nr_oddziału;//przypisuje wartość
				}
		}
	// Update is called once per frame
	void Update () {
		if (ilość_jednostek==0 ||panel_główny.GetComponent<wybór_oddziału>().przeniesienie_do==null) {
			przycisk.GetComponent<Button>().interactable=false;//desaktywacja przycjisku
				}
		else {
			przycisk.GetComponent<Button>().interactable=true;//aktywowanie przycisku
				}
		if (rodzaj_jednostki=="wojownik") {
			ilość_jednostek = panel_główny.GetComponent<wybór_oddziału> ().pochodzenie.GetComponent<skład_armi> ().ilość_wojowników;
				}
		if (rodzaj_jednostki=="uzdrowiciel") {
			ilość_jednostek = panel_główny.GetComponent<wybór_oddziału> ().pochodzenie.GetComponent<skład_armi> ().ilość_uzdrowicieli;
				}


		wyświetlacz_ilości.GetComponent<Text> ().text = ""+ilość_jednostek ;//przypisuje ciąg znaków
		aktualnie_wybrana_ilość.GetComponent<Text> ().text = "" + wartości.value;//przypisuje ciąg znaków
	}
}
