using UnityEngine;
using System.Collections;

public class AI_wojownika : MonoBehaviour {
	public do_celu _do_celu; //odnośnik do skryptu do_celu
	private podąrzanie _podąrzanie;//odnośnik do skryptu podąrzanie
	public bool nowy_cel;//przechowuje zmienną logiczną 
	public nadawanie_celu _nadawanie_celu;//odnośnik do sktyptu nadawanie_celu
	public Vector3 cel;//pozycja do skryptu do_celu
	private NavMeshAgent agent;//odnośnik do komponentu NavMeshAgent
	private Animator anim;//odnośnik do komponentu Animator
	public bool _wróg_collider;//zmmienna ligiczna stwierdzającza czy wroga jednostka została wykryta
	public float odliczanie;//określa czas po jakim zmiena nowy_cel przechodzi w wartość false
	private Życie _życie;//odnośnik do skryptu życie
	public przynależność _przynależność; //odnośnik do skryptu przynależność
	public Atak_wojownika _Atak_wojownika;//odnośnik do skryptu Atak_wojownika
	public GameObject czępion;//przechowuje informacje na temat dowódcy oddziału
	private patrol _patrol;//odnośnik do skryptu patrol

	void Start () {
		_do_celu=GetComponent<do_celu>();//przypisanie skryptu
		_podąrzanie = GetComponent<podąrzanie> ();//przypisanie skryptu
		_nadawanie_celu = GameObject.Find ("GameMaster").GetComponent<nadawanie_celu> ();//przypisanie skryptu
		agent = GetComponent<NavMeshAgent> ();//przypisanie komponentu
		anim = GetComponent<Animator> ();//odnośnik do komponentu
		_wróg_collider = GetComponent<wykrywanie_wroga> ().enemyInRange;//przypisanie skryptu
		_życie = GetComponent<Życie> ();//przypisanie skryptu
		_przynależność = GetComponent<przynależność> ();//przypisanie skryptu
		_Atak_wojownika = GetComponent<Atak_wojownika> ();//przypisanie skryptu
		_patrol = GetComponent<patrol> ();//przypisanie skryptu

	}
	void Update () {
		if (_przynależność.Nr_oddziału!=0) {

						if (GameObject.Find ("Zarządzanie grupa " + _przynależność.Grupa).GetComponent<dowódctwo> ().czępion.Count != 0) {
								czępion = GameObject.Find ("Zarządzanie grupa " + _przynależność.Grupa).GetComponent<dowódctwo> ().czępion [_przynależność.Nr_oddziału - 1];
			}//przydzielanie dowódcy
				}
		if (_życie.śmierć) {
			gameObject.tag="trup";//zmiana tagu jednostki
			_nadawanie_celu.lista_w_oddziale.Remove (gameObject);//usuwanie jednostki z listy
			_podąrzanie.enabled = false;//wyłączenie skryptu
			_do_celu.enabled = false;//wyłączenie skryptu
			nowy_cel = false;//zmiana wartości zmiennel logicznej
			_Atak_wojownika.enabled = false;//wyłączenie skryptu
			agent.enabled=false;//wyłączenie komponentu
			Vector3 w=new Vector3(0,1,0);//przypisywanie wektora
			gameObject.GetComponent<CharacterController>().Move(w*Time.deltaTime);//unoszenie jednostki po śmierci
			}
		else {
			   if (!_wróg_collider) {
				anim.SetBool("między_atakami",false);//wyłącznie animacji
				agent.stoppingDistance=4f;//zmiana odległości zatczymania od celu
				_Atak_wojownika.enabled = false;//wyłączenie skryptu
				if (nowy_cel) {
					_patrol.enabled=false;//wyłączenie skryptu
					_podąrzanie.enabled = false;//wyłączenie skryptu
					_do_celu.Idź(cel);//uruchomienie funkcji
					if (Vector3.Distance(gameObject.transform.position,cel)<4) {
						odliczanie += Time.deltaTime;//naliczanie
						if (odliczanie > 2) {
							nowy_cel = false;//zmiana wartości zmiennel logicznej
							odliczanie = 0;//zerowanie
							
						}
					            }
							    
				}
				if (!nowy_cel) {
					if (czępion!=null) {
						if (czępion.tag=="Czepion"||czępion.tag=="Gracz") {
							_podąrzanie.przywódca=czępion;//przydzielanie celu
							_patrol.enabled=false;//wyłączenie skryptu
							_podąrzanie.enabled = true;//włączanie  skryptu

						}
						if (czępion.tag=="obóz") {
							agent.stoppingDistance=1f;//zmiana odległości zatczymania od celu
							_podąrzanie.enabled = false;//wyłączenie skryptu
							_patrol.enabled=true;//włączanie  skryptu
						}
					}

						if (_przynależność.Grupa == 1 && _przynależność.Nr_oddziału==1) {
							if (!_nadawanie_celu.lista_w_oddziale.Contains (gameObject)) {
								_nadawanie_celu.lista_w_oddziale.Add (gameObject);//dodawanie jednostki do listy
							}

						}

				}
				

			} 
			else {

				agent.stoppingDistance=3f;//zmiana odległości zatczymania od celu
				_patrol.enabled=false;//wyłączenie skryptu
				_podąrzanie.enabled = false;//wyłączenie skryptu
				_do_celu.enabled = false;//wyłączenie skryptu
				_Atak_wojownika.enabled = true;//włączanie  skryptu
				nowy_cel=false;//zmiana wartości zmiennel logicznej
						}
				}
		if (agent.desiredVelocity.magnitude>0) {
			anim.SetBool("walk",true);//włączanie animacji
			anim.SetBool("między_atakami",false);//wyłącznie animacji
				}
		else {
			anim.SetBool("walk",false);//wyłącznie animacji
				}
				}
	
}