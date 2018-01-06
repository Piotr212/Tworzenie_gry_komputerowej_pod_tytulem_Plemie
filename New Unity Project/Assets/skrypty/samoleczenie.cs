using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class samoleczenie : MonoBehaviour {
	public GameObject rzuczjący;//przechowuje dane obiektu
	public void użycie()
	{
		czry _czary=new czry();//odniesienie do sktyptu
		_czary.leczenie (rzuczjący, rzuczjący);//uruchamia funkcję
		}
}
