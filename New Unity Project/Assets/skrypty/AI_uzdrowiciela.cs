using UnityEngine;
using System.Collections;

public class AI_uzdrowiciela : MonoBehaviour {
	private podąrzanie _podąrzanie;  //odnośnik do skryptu podąrzanie
	public GameObject cel_do_uzdrowienia;//przechowuje dane obiektu
	public do_celu _do_celu;//odnośnik do skryptu do_celu
	private NavMeshAgent agent;//odnośnik do komponentu NavMeshAgent
	private Animator anim;//odnośnik do komponentu Animator
	private Życie _życie;//odnośnik do skryptu Życie
	public przynależność _przynależność;//odnośnik do skryptu przynależność
	public GameObject czępion;//przechowuje informacje na temat dowódcy oddziału
	private patrol _patrol;//odnośnik do skryptu patrol
	private uzdrowienie_sojusznika _uzdrowienie_sojusznika;//odnośnik do skryptu uzdrawianie_sojusznika
	private szukanie_rannego _szukanie_rannego;//odnośnik do skryptu  szukanie_rannego
	void Start () {
		_podąrzanie = GetComponent<podąrzanie> ();//przypisanie skryptu
		agent = GetComponent<NavMeshAgent> ();//przypisanie komponentu
		anim = GetComponent<Animator> ();//przypisanie komponentu
		_życie = GetComponent<Życie> ();//przypisanie skryptu
		_przynależność = GetComponent<przynależność> ();//przypisanie skryptu
		_patrol = GetComponent<patrol> ();//przypisanie skryptu
		_szukanie_rannego = GetComponent<szukanie_rannego> ();//przypisanie skryptu
		_uzdrowienie_sojusznika = GetComponent<uzdrowienie_sojusznika> ();//przypisanie skryptu
		_do_celu = GetComponent<do_celu> ();//przypisanie skryptu
	}
	void Update () {
		if (_przynależność.Nr_oddziału != 0) {
						if (GameObject.Find ("Zarządzanie grupa " + _przynależność.Grupa).GetComponent<dowódctwo> ().czępion.Count != 0) {
								czępion = GameObject.Find ("Zarządzanie grupa " + _przynależność.Grupa).GetComponent<dowódctwo> ().czępion [_przynależność.Nr_oddziału - 1];
			}//przydzielanie dowódcy
				}
		if (_życie.śmierć) {
			gameObject.tag="trup";//zmiana tagu jednostki
			_podąrzanie.enabled = false;//wyłączenie skryptu
			agent.enabled=false;//wyłączenie komponentu
			Vector3 w=new Vector3(0,1,0);//przypisywanie wektora
			gameObject.GetComponent<CharacterController>().Move(w*Time.deltaTime);//unoszenie jednostki po śmierci
		}
		else {
			cel_do_uzdrowienia=_szukanie_rannego.sojusznik;//przydzielania celu
			if (cel_do_uzdrowienia==null) {
				_uzdrowienie_sojusznika.enabled=false;//wyłączenie skryptu
				if (tag!="Czępion") {
					_do_celu.enabled=false;//wyłączenie skryptu
				
				if (czępion!=null) {
					if (czępion.tag=="Czepion"||czępion.tag=="Gracz") {
							_podąrzanie.przywódca=czępion;//przydzielanie celu
							_patrol.enabled=false;//wyłączenie skryptu
							_podąrzanie.enabled = true;//włączanie  skryptu
						
					}
					if (czępion.tag=="obóz") {
							_podąrzanie.enabled = false;//wyłączenie skryptu
							_patrol.enabled=true;//włączanie  skryptu
							_podąrzanie.przywódca=null;//usuwanie celu
					}
				}
				}
				else {
					_patrol.enabled=false;//wyłączenie skryptu
					_podąrzanie.enabled=false;//wyłączenie skryptu
					_do_celu.enabled=true;//włączanie  skryptu
				}
			}
			else {
				_patrol.enabled=false;//wyłączenie skryptu
				_podąrzanie.enabled=false;//wyłączenie skryptu
				_uzdrowienie_sojusznika.cel=cel_do_uzdrowienia;//przydzielanie celu
				_uzdrowienie_sojusznika.enabled=true;//włączanie  skryptu
				_szukanie_rannego.sojusznik=null;//usuwanie celu
				cel_do_uzdrowienia=null;//czyszczenie zmiennej
			}
				}
		if (agent.desiredVelocity.magnitude>0) {
			anim.SetBool("walk",true);//włączanie animacji
		}
		else {
			anim.SetBool("walk",false);//wyłącznie animacji
		}
	
	}
}
