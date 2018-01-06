using UnityEngine;
using System.Collections;

public class Kamera_trzeciosobowa : MonoBehaviour {
	public GameObject _cel;//przechowuje dane obiektu
	public float wysokość;//przechowuje wartość liczbową rzeczywistą
	public float odległość=2f;//przechowuje wartość liczbową rzeczywistą
	private float x;//przechowuje wartość liczbową rzeczywistą
	private float y;//przechowuje wartość liczbową rzeczywistą
	private float Speed=500f;//przechowuje wartość liczbową rzeczywistą
	private float dystans;//przechowuje wartość liczbową rzeczywistą
	void Update(){

		if (Input.GetMouseButton(2)) {
			y -= Input.GetAxis("Mouse Y") * Speed * 0.02f;//pyznaczanie przesunięcia
			x += Input.GetAxis("Mouse X") * Speed * 0.02f;//pyznaczanie przesunięcia
				}
		Quaternion rotation = Quaternion.Euler(y, x, 0);//wyznaczene rotacji
		Vector3 position = rotation *new Vector3(0.0f, 0.0f+wysokość,-odległość) + _cel.transform.position;//wyznaczanie pozycji
		transform.rotation = rotation;//przypisanie rotacji
		transform.position = position;//przypisanie pozycji
		float dystans=odległość+ 1.0f; // aktualna odległość od celu
		Ray ray=new Ray(_cel.transform.position, transform.position-_cel.transform.position);//tworzy odcinel pomiędzy kamerą a celem
		RaycastHit hit;//przechowuje dane o końcowym wierzchołku odcinka Ray 
		if(Physics.Raycast(ray,out hit, dystans)){
			// store the distance;
			dystans=hit.distance - 1.0f;//przypisuje wartość
		}
		if(dystans>odległość)dystans=odległość;//przypisuje wartość
		if(dystans<1.0f)dystans=1.0f;
		transform.position = ray.GetPoint(dystans);//przypisuje pozycję
		}

}
