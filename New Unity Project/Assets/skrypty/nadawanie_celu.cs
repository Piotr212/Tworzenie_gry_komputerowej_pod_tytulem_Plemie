using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class nadawanie_celu : MonoBehaviour {
	public Vector3 cel;//przechowuje dane pozycji
	public List<GameObject>lista_w_oddziale=new List<GameObject>();//przechowuje liste danych obiektów
	public AI_wojownika _Ai_wojownika;//przechowuje sktypt
	public bool _UI;

	void Start () {
		_UI = true;//nadaje wartośc logiczną
	}

	void Update () {
		if (_UI) {

		if (lista_w_oddziale.Count!=0) {
	            _Ai_wojownika = lista_w_oddziale [0].GetComponent<AI_wojownika> (); //przypisuje sktypt
				RaycastHit hit;//przechowuje dane o końcowym wierzchołku odcinka Ray 
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//tworzy odcinel pomiędzy kamerą a celem
				if (Input.GetMouseButtonDown (0)) {
						if (Physics.Raycast(ray.origin,ray.direction, out hit))
					{
						cel=hit.point;//przypisuje pozycję
					}

				_Ai_wojownika.nowy_cel=true;//zmienia wartoś logiczną
				_Ai_wojownika.cel=cel;//przypisuje pozycję
				lista_w_oddziale.RemoveAt(0);//usuwa z listy obiekt o indexie 0
						}
				}
				}
	}
}
