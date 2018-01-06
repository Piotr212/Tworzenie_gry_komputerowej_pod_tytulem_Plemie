using UnityEngine;
using System.Collections;

public class wykrywanie_wroga : MonoBehaviour {

	public GameObject wróg;//przechowuje dane obiektu
	private przynależność nalerzy;//odnośnik do skryptu
	private przynależność wroga_przynależność;//odnośnik do skryptu
	public bool enemyInRange;//przechowuje zmienną logiczną
	private Życie życie_wroga; //odnośnik do skryptu
	private AI_wojownika _AI_wojownika;//odnośnik do skryptu
	private Animator anim;//odnośnik do kpmponentu
	private Atak_wojownika _Atak_wojownika;//odnośnik do skryptu
	void Start () {
		wróg = null;//czyszczenie
		_AI_wojownika = GetComponent<AI_wojownika> ();//przypisanie sktyptu
		nalerzy = GetComponent<przynależność> ();//przypisanie sktyptu
		_AI_wojownika._wróg_collider = false;//zmiana zmiennej logicznej
		anim = GetComponent<Animator> ();//przypisanie komponentu
	}
	void OnTriggerStay (Collider other)
	{
		if (wróg==null) {

			if (other.gameObject.CompareTag ("Unit") || other.gameObject.CompareTag ("Czepion")||other.gameObject.CompareTag ("Gracz")||other.gameObject.CompareTag ("chata")) {
				wroga_przynależność = other.gameObject.GetComponent<przynależność> ();//przypisanie sktyptu
				if (wroga_przynależność.Grupa != nalerzy.Grupa && wroga_przynależność.Grupa !=0) {
					wróg = other.gameObject;//przypisanie obiektu
					życie_wroga =wróg.GetComponent<Życie> ();//przypisanie sktyptu
					if (!życie_wroga.śmierć) {
						enemyInRange = true;//zmiana zmiennej logicznej
					}
				}
			}
				}

		
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == wróg)
		{
			brak_wroga();//uruchomienie funkcji
		}
	}
	void brak_wroga()
	{

		enemyInRange = false;//zmiana zmiennej logicznej
		wróg=null;//czyszczenie
		życie_wroga = null;//czyszczenie
		anim.SetBool ("Atak", false);//wyłącznie animacji
		
	}
	// Update is called once per frame
	void Update () {
		_AI_wojownika._wróg_collider = enemyInRange;//przypisanie wartości
		if (wróg!=null) {
			if (życie_wroga.śmierć) {
				brak_wroga();//uruchomienie funkcji
			}
				}

	}
}