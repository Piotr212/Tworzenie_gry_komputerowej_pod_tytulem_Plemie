using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class czry{
	public void leczenie(GameObject rzuzający,GameObject cel)
	{
		rzuzający.GetComponent<mana> ().stan_many -= 20;//odejmowanie punktów many
		rzuzający.GetComponent<Animator>().SetBool("Czar", true);//włączanie animacji
		rzuzający.GetComponent<blask_czaru>().blask.GetComponent<ParticleSystem> ().enableEmission=true;//aktywacja emisji blasku
				cel.GetComponent<Życie>().currentHealth+=50;//dodawanie stanu życia
		}
}
