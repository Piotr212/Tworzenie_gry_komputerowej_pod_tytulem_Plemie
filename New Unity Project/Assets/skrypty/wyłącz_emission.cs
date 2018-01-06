using UnityEngine;
using System.Collections;

public class wyłącz_emission : MonoBehaviour {
	public float czas;//przechowuje wartość liczbową rzeczywistą
	private float miniony_czas=0f;//przechowuje wartość liczbową rzeczywistą

	void Update () {
		if (gameObject.GetComponent<ParticleSystem> ().enableEmission) {
			miniony_czas+=Time.deltaTime;//naliczanie
			if (miniony_czas>=czas) {
				miniony_czas=0;//zerowanie
				gameObject.GetComponent<ParticleSystem> ().enableEmission=false;//wyłączenie funkcji
			}
				}
	}
}
