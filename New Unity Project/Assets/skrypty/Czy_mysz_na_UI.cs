using UnityEngine;
using System.Collections;

public class Czy_mysz_na_UI : MonoBehaviour {
    public void jest_na()
	{
		GameObject.Find ("GameMaster").GetComponent<nadawanie_celu> ()._UI = false;//zmiana wartości zmiennel logiczne
	}
	public void nie_jest_na()
	{
		GameObject.Find ("GameMaster").GetComponent<nadawanie_celu> ()._UI = true;//zmiana wartości zmiennel logiczne
	}
}
