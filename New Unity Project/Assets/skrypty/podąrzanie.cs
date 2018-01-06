using UnityEngine;
using System.Collections;

public class podąrzanie : MonoBehaviour {
	public GameObject przywódca;//przechowuje dane obiektu
	private NavMeshAgent agent;//odnośnik do komponentu NavMeshAgent
	void Start () {
		agent = GetComponent<NavMeshAgent> ();//przypisanie komponentu
		}
	void Update () {
				if (przywódca != null) {
                            agent.SetDestination (przywódca.transform.position);//nakaz przemieszczenia się obiektu w kerunku celu
				}

		}
		
}
