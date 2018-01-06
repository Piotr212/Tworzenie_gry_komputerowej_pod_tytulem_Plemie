using UnityEngine;
using System.Collections;

public class Atak_wojownika : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f; //czas pomiędzy na wykonanie następnego ataku     
	public int attackDamage = 10;   // ilość zadawanych obrażeń            
	public GameObject wróg;// odnośnik do wrogiej atakowanej jednostki
	wykrywanie_wroga szukanie;//odnośnik do skryptu szukanie
	private Animator anim;//odnośnik do komponentu Animator                                    
	private Życie życie_wroga;// odnośnik do skryptu życie wrogiej jednostki           
	private przynależność wroga_przynależność;//odnośnik do skryptu przynależność wroga                     
	private float timer;//nalicza czas do następnego ataku                           
	public NavMeshAgent agent;//odnośnik do komponentu NavMeshAgent
	wykrywanie_wroga _wyktywanie_wroga;//odnośnik do skryptu  wykrywanie_wroga
	void Start ()
	{
		anim = GetComponent <Animator> ();//przypisanie komponentu
		_wyktywanie_wroga = GetComponent<wykrywanie_wroga> ();//przypisanie skryptu
		agent = GetComponent<NavMeshAgent> ();//przypisanie komponentu
	}
	
	
	void Update ()
	{
		wróg = _wyktywanie_wroga.wróg;//przypisanie wroga
		if (wróg!=null) {
			życie_wroga = wróg.GetComponent <Życie> ();//przypisanie skryptu
			timer += Time.deltaTime;//naliczanie
			float dystans;//przechowuje odległość pomiędzy jednostką a wrogą jednostką
			dystans=Vector3.Distance(transform.position,wróg.transform.position);//wyliczanie odległości
			if (dystans<=3.3f) {
				anim.SetBool("między_atakami",true);//włączanie animacji
				if(timer >= timeBetweenAttacks)
				{
					Attack ();//uruchomienie funkcji
					anim.SetBool ("Atak", true);//włączanie animacji
				}
				else {
					anim.SetBool ("Atak", false);//wyłącznie animacji
				}
			}
			else {
				agent.SetDestination(wróg.transform.position);
			}
			}

	}
	void Attack ()
	{
		timer = 0f;//zerowanie
		if(życie_wroga.currentHealth > 0)
		{
			życie_wroga.TakeDamage (attackDamage);//aktywacja funkcji
		}
	}
}
