using UnityEngine;
using System.Collections;

public class zbieranie_sórowców : MonoBehaviour {
	private NavMeshAgent agent;//odnośnik do komponentu
	private GameObject[] drzewa;//przechowuje tablice obiektów
	public GameObject sórowiec;//przechowuje dane obiektu
	private float timer;//przechowuje wartość liczbową rzeczywistą
	public float czas_między_zbieraniem = 0.5f;  //przechowuje wartość liczbową rzeczywistą
	private int pozostałość_sórowca;//przechowuja wartość liczbową naturalną
	public int zbierany=10;//przechowuja wartość liczbową naturalną
	public int niesiony=0;//przechowuja wartość liczbową naturalną
	public GameObject magazym;//przechowuje dane obiektu
	private Animator anim;//odnośnik do komponentu
	void Start () {
		sórowiec = null;//usuwanie zawartości
		agent = GetComponent<NavMeshAgent> ();//przypisanie komponentu
		anim = GetComponent<Animator> ();//przypisanie komponentu


	}

	void Update () {
		if (GameObject.FindGameObjectWithTag("drzewo")) {
			drzewa=GameObject.FindGameObjectsWithTag("drzewo");//odnajduje i przypisuje obiekt
				}

		if (magazym==null) {
			GameObject[] chaty = GameObject.FindGameObjectsWithTag ("chata");//odnajduje i przypisuje obiekty
			foreach (var item in chaty) {
				if (item.GetComponent<przynależność>().Grupa==gameObject.GetComponent<przynależność>().Grupa) {
					magazym=item;//przypisuje obiekt
					continue;//wychodzi z pętli
				}
			}
				}
		if (agent.desiredVelocity.magnitude>0) {
			anim.SetBool("walk",true);//włączanie animacji
		}
		else {
			anim.SetBool("walk",false);//wyłącznie animacji
		}
		if (niesiony>=150) {
			agent.SetDestination(magazym.transform.position);//przemieszczenie obiektu w kierunku celu
			float dystans=Vector3.Distance(gameObject.transform.position,magazym.transform.position);//wyliczanie odległości i jej przypisanie
			if (dystans<=3.5f) {
				GameObject.Find("GameMaster").GetComponent<Surowce>().ilość+=niesiony;//dodanie wartości
				niesiony=0;//zerowanie
			}
		}
	 else {
			if (sórowiec==null) {
				float dystans=10000f;
				foreach (var item in drzewa) {
					if (sórowiec==null) {
						sórowiec=item;//przypisanie obiektu
						dystans=Vector3.Distance(gameObject.transform.position,item.transform.position);//wyliczanie odległości i jej przypisanie
					}
					else {
						float dystans1=Vector3.Distance(gameObject.transform.position,item.transform.position);//wyliczanie odległości ijej przypisanie
						if (dystans>dystans1) {
							sórowiec=item;//przypisanie obiektu
							dystans=dystans1;//przypisanie wartości
						}
					}
				}

			}
			else {
				agent.SetDestination(sórowiec.transform.position);//przemieszczenie obiektu w kierunku celu
				float dystans2;//przechowuja wartość liczbową naturalną
				dystans2=Vector3.Distance(transform.position,sórowiec.transform.position);//wyliczanie odległości i jej przypisanie
				if (dystans2<=3f) {
					timer += Time.deltaTime;//naliczanie
					pozostałość_sórowca=sórowiec.GetComponent <ilość_sórowce>().ilość;//przypisanie wartości
					if (timer>=czas_między_zbieraniem) {
						anim.SetBool("rąbanie",true);//włączanie animacji
						pozostałość_sórowca-=zbierany;//odejmowanie wartości
						niesiony+=zbierany;//dodawanie wartości
						timer=0;//zerowanie
					}
				}
				
				if (pozostałość_sórowca<=0) {
					sórowiec=null;//usuwanie przypisania
				}
			}
				}

	}
}
