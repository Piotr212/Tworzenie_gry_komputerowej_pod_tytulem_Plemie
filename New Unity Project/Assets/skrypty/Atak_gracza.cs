using UnityEngine;
using System.Collections;

public class Atak_gracza : MonoBehaviour {
	public float timeBetweenAttacks = 0.5f; //czas pomiędzy na wykonanie następnego ataku 
	public int attackDamage = 10;// ilość zadawanych obrażeń	
	private Animator anim;//odnośnik do komponentu Animator
	public GameObject wróg;// odnośnik do wrogiej atakowanej jednostki
	Życie życie_wroga;// odnośnik do skryptu życie wrogiej jednostki	
	public bool enemyInRange;// zmienna logiczna określająca czy wróg jest w zasięgu
	private float timer;//nalicza czas do następnego ataku                   
	private przynależność nalerzy;//odnośnik do skryptu przynależność
	private przynależność wroga_przynależność;//odnośnik do skryptu przynależność wroga
	void Start () {
		nalerzy = GetComponent<przynależność> (); //przypisanie skryptu
		anim = GetComponent <Animator> ();//przypisanie komponentu
	}
	void OnTriggerStay (Collider other)
	{
				
		if (other.gameObject.CompareTag ("Unit")||other.gameObject.CompareTag ("Czepion")||other.gameObject.CompareTag ("Gracz")||other.gameObject.CompareTag ("chata")) {
			wroga_przynależność = other.gameObject.GetComponent<przynależność> ();//przypisanie skryptu
			if (wroga_przynależność.Grupa != nalerzy.Grupa && wroga_przynależność.Grupa !=0) {
				wróg = other.gameObject;//przypisanie wroga
				enemyInRange = true;//zmiana wartości zmiennel logicznej
				życie_wroga = wróg.GetComponent <Życie> ();//przypisanie skryptu
					
								}
						}


	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == wróg)
		{
			brak_wroga();//aktuwowanie funkcji
		}
	}
	// Update is called once per frame
	void Update () {
		if (wróg!=null) {
			if (życie_wroga.śmierć) {
				brak_wroga();//aktuwowanie funkcji
				}
				}
		timer += Time.deltaTime;//naliczanie
		if (timer >= timeBetweenAttacks && Input.GetButton ("Atak_bronią")) {
						timer = 0f;//zerowanie
						if (wróg != null) {
				anim.SetBool("między_atakami",true);//włączanie animacji
				anim.SetBool ("Atak", true);//włączanie animacji
	
								if (enemyInRange) {
										Attack ();//aktywacja funkcji
								} 
						}
			else {
				anim.SetBool("między_atakami",false);//wyłącznie animacji
			}
				}
		else {

			anim.SetBool ("Atak", false);//wyłącznie animacji
		}
	}
	void brak_wroga()
	{
		anim.SetBool("między_atakami",false);//wyłącznie animacji
		enemyInRange = false;//zmiana wartości zmiennel logicznej
		wróg=null;//czyszczenie zmiennej
		życie_wroga = null;//czyszczenie zmiennej
		}
	void Attack ()
	{
		if(życie_wroga.currentHealth > 0)
		{
			życie_wroga.TakeDamage (attackDamage);//aktywacja funkcji
		}
	}
}
