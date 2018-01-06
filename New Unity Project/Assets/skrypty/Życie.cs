using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Życie : MonoBehaviour {
	public int startingHealth = 100;//przechowuja wartość liczbową naturalną                            
	public int currentHealth;//przechowuja wartość liczbową naturalną                                   
	public Slider healthSlider;                                                                  
	private Animator anim;                                                                                                                           
	public float czas=7f;
	float czas1=0f;
	public int ilość_regeneracji=2;//przechowuja wartość liczbową naturalną
	public float czas_do_regeneracji=3f;
	public bool śmierć=false;//przechowuje zmienną logiczną
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		currentHealth = startingHealth;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (śmierć) {
			czas -= Time.deltaTime;
			if (tag=="chata") {
				czas=0f;
			}
			if (czas<=0f) {
				Destroy (gameObject);
			}
				}
		if (currentHealth>0&&currentHealth<startingHealth) {
			regeneracja();
				}
		if (currentHealth>startingHealth) {
			currentHealth=startingHealth;
				}
		healthSlider.value = currentHealth;
	}
	public void TakeDamage (int amount)
	{
		healthSlider.maxValue = startingHealth;
		currentHealth -= amount;

		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	void regeneracja()
	{
		czas1 += Time.deltaTime;
		if (czas1>=czas_do_regeneracji) {
			currentHealth +=ilość_regeneracji;
			czas1=0f;
				}

		}
	
	void Death ()
	{
		śmierć = true;
		if (tag!="chata") {
			anim.SetTrigger ("Dead");
				}

	}       
}
