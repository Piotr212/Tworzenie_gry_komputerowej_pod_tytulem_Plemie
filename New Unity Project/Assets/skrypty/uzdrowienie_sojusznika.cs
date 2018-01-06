using UnityEngine;
using System.Collections;

public class uzdrowienie_sojusznika : MonoBehaviour {
	public GameObject cel;//przechowuje dane obiektu
	private NavMeshAgent agent;//odnośnik do komponentu
	private float dystans;//przechowuje wartość liczbową rzeczywistą

	void Start () {
		agent = GetComponent<NavMeshAgent> ();//przypisanie komponentu
	}
	

	void Update () {
	if (cel!=null) {
			dystans=Vector3.Distance(transform.position,cel.transform.position);
			if (dystans>7) {
				agent.SetDestination(cel.transform.position);//nakaz przemieszczenia obiektu w kierunku danego celu
			}
			else {
				if (GetComponent<mana>().stan_many>=50) {
					czry _czary=new czry();//odnośnik do skryptu
					_czary.leczenie (gameObject, cel);//urzycie funkcji
				}
				cel=null;//czyszczenie 
			}
				}
	}
}
