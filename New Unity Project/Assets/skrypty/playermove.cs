using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class playermove : MonoBehaviour
{
	public float rotatespeed=25.0f;//przechowuje wartość liczbową rzeczywistą
	public float speed=3.0f;//przechowuje wartość liczbową rzeczywistą
	public float gravity=10.0f;//przechowuje wartość liczbową rzeczywistą
	private Transform _playertransform;//przechwuje komponent
	private Vector3 _moveDirection;//przechowuje pozycję
	private Animator anim;//odnośnik do komponentu Animator
	private CharacterController _playercontroller;//przechowuje komponent CharacterController
	public void Awake()
	{
		_playertransform = transform;//przypisuje komponent
		_playercontroller = GetComponent<CharacterController> ();//przypisuje komponent
		anim = GetComponent<Animator> ();//przypisuje komponent
	}
	void Start()
	{
		_moveDirection = Vector3.zero;//przypisowuje pozycję
	}
	void Update()
	{
		float v = Input.GetAxisRaw("Vertical");//przypisuje wartość
		float h = Input.GetAxisRaw ("Horizontal");//przypisuje wartość
		poruszanie (v, h);//aktywuje funkcję
		aniation (v,h);//aktywuje funkcję

	}
	void poruszanie(float v,float h)
	{
		_moveDirection= new Vector3(0,0,v);//wyznacza punkt
		_moveDirection=_playertransform.TransformDirection(_moveDirection);//przemieszcz obekt w kierumku punktu
		_moveDirection.y -= gravity*Time.deltaTime;//przypisuje wartość
		 _playercontroller.Move(_moveDirection*Time.deltaTime*speed);//przemieszcza obiekt 
		_playertransform.Rotate (0, h, 0);//obraca obiektem
	}
	void aniation(float v,float h)
	{
		bool wallking= v !=0f ||h!=0f;//przpisowuje wartość lobiczną
		anim.SetBool("walk",wallking);//przpisowuje wartość lobiczną do komponentu
	}
}