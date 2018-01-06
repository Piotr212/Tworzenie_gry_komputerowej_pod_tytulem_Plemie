using UnityEngine;
using System.Collections;

public class patrol : MonoBehaviour {
	private NavMeshAgent agent;//odnośnik do komponentu NavMeshAgent
	private int numer_punktu;//przechowuje wartość liczbową naturalną
	private float dystans;//przechowuje wartość liczbową rzeczywistą
	private AI_wojownika AI;//pozycja do skryptu AI_wojownika
	void Start () {
		agent = GetComponent<NavMeshAgent> ();//odnośnik do komponentu
		numer_punktu = 0;//przypisanie liczby
		AI = GetComponent<AI_wojownika> ();//przypisanie skryptu
	}
	
	// Update is called once per frame
	void Update () {
		dystans=Vector3.Distance(transform.position,AI.czępion.GetComponent<punkty_patrolowe>().punkty[numer_punktu].transform.position);//obliczanie dystansu ponięczy obiektami
		if (dystans>3) {
			agent.SetDestination(AI.czępion.GetComponent<punkty_patrolowe>().punkty[numer_punktu].transform.position);//obiekt udaje się do celu
				}
		else {
			numer_punktu=Random.Range(0,AI.czępion.GetComponent<punkty_patrolowe>().punkty.Count);//wylosowanie liczby i przypisanie
				}
	}
}
