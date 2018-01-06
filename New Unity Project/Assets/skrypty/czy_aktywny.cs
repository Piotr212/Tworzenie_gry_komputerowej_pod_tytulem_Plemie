using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class czy_aktywny : MonoBehaviour {
	void Update () {
	if (gameObject.GetComponent<do_sceny>().nazwa_sceny!="") {
			gameObject.GetComponent<Button>().interactable=true;//aktuwuje przycisk
				}
		else {
			gameObject.GetComponent<Button>().interactable=false;//desaktywuje przycisk 
				}
	}
}
