using UnityEngine;
using System.Collections;

public class szukanie_rannego : MonoBehaviour {
	public GameObject sojusznik;//przechowuje dane obiektu
	private przynależność nalerzy;//odnośnik do skryptu
	private przynależność przynależność_sojusznika;//odnośnik do skryptu

	void Start () {
		nalerzy = GetComponent<przynależność> ();//przypisanie skryptu
	}

	void OnTriggerStay (Collider other)
	{
		if (sojusznik==null) {
			
			if (other.gameObject.CompareTag ("Unit") || other.gameObject.CompareTag ("Czepion")||other.gameObject.CompareTag ("Gracz")) {
				przynależność_sojusznika = other.gameObject.GetComponent<przynależność> ();//przypisanie skryptu
				if (przynależność_sojusznika.Grupa == nalerzy.Grupa) {
					if (other.gameObject.GetComponent<Życie>().currentHealth<50) {
						sojusznik= other.gameObject;//przypisanie obiektu
					}
				}
			}
		}
		
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
