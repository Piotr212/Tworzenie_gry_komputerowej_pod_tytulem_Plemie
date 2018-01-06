using UnityEngine;
using System.Collections;

public class zdawanie_surowców : MonoBehaviour {
	public Surowce _surowce;
	private przynależność _swoja_przynalerzność;
	private przynależność _przynalerzność_robotnika;
	private zbieranie_sórowców _zbieranie;
	void Start () {
		_surowce = GameObject.Find ("GameMaster").GetComponent<Surowce> ();
		_swoja_przynalerzność = gameObject.GetComponent<przynależność> ();
	}
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.name=="robotnik") {
			_przynalerzność_robotnika=other.gameObject.GetComponent<przynależność>();
			if (_swoja_przynalerzność.Grupa==_przynalerzność_robotnika.Grupa) {
				_zbieranie=other.gameObject.GetComponent<zbieranie_sórowców>();
				_surowce.ilość+=_zbieranie.niesiony;
				_zbieranie.niesiony=0;

			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
