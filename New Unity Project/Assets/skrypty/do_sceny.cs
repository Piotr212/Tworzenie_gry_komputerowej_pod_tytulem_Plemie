using UnityEngine;
using System.Collections;

public class do_sceny : MonoBehaviour {
	public string nazwa_sceny=null;//przechowuje ciąg znaków

	public void przejście()
	{
		Application.LoadLevel (nazwa_sceny);//wczytywanie sceny
		}
}
