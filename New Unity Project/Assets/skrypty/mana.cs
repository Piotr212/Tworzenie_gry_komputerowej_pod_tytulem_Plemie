using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class mana : MonoBehaviour {
	public int stan_many;//przechowuje wartość naturalną
	public int max_many=100;//przechowuje wartość naturalną
	public Slider pasek_many;//przechoeuje dane Slieder(suwak)
	public int ilość_regenerowana=3;//przechowuje wartość naturalną
	private float czas=0f;//przechowuje wartość liczbową rzeczywistą
	public float czas_do_regeneracji=3f;//przechowuje wartość liczbową rzeczywistą

	void Start () {
		stan_many = max_many;//przypisanie wartości
	}
	
	// Update is called once per frame
	void Update () {
	if (stan_many<100) {
			regeneracja();//urzycie funkcji
				}
		if (stan_many>max_many) {
			stan_many=max_many;//przypisanie wartości
				}
		pasek_many.value = stan_many;//przypisanie wartości
	}
	void regeneracja()
	{
		czas+= Time.deltaTime;//naliczanie
		if (czas>=czas_do_regeneracji) {
			stan_many += ilość_regenerowana;//dodawanie do wartości
			czas=0;//zerowanie
				}

		}
}
