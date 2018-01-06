using UnityEngine;
using System.Collections;

public class u_celu : MonoBehaviour {
	public bool jest=false;//przechowuje zmienną logiczną

	void OnTriggerEnter (Collider other){
		if (other.gameObject.name =="Postac" ) {
			jest=true;//zmianna wartości logicznej
			}

		}
}
