using UnityEngine;
using System.Collections;

public class do_celu : MonoBehaviour {
	private NavMeshAgent agent;//odnośnik do komponentu NavMeshAgent
	public Vector3 _cel;//przechowuje pozycję celu
	void Start () {
		agent = GetComponent<NavMeshAgent> ();//przypisanie komponentu
	}
	public void Idź (Vector3 cel) {
		_cel = cel;//przypisuje pozycję
		agent.SetDestination (_cel);//nakaz przemieszczenia się obiektu w kerunku celu

				
	}

	}

