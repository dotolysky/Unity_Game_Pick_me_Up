using UnityEngine;
using System.Collections;
using System.Threading;

public class crane_mv : MonoBehaviour {
//	public bool Cranebox_On = false;
	public Transform target;
	public GameObject crane=null;
	public GameObject craneaa=null;
	public GameObject cranebb = null;
	public GameObject cranecc = null;
	public GameObject crane1=null;
	public GameObject crane2=null;
	public GameObject crane3=null;
	public GameObject crane4=null;
	public GameObject cube=null;
	public GameObject f=null;
	public GameObject r=null;
	public GameObject l=null;
	public GameObject b=null;
	private AudioSource sc;
	public AudioClip aclip;
	Vector3 drop_sec;
	Vector3 pointas;
	Vector3 pointas2;
	Vector3 pointas3;
	Vector3 pointas4;
	float speed = 2.0f;
	public float timer;
	bool crane_unlock = true;
	bool space_unlock = true;
	public RaycastHit hit;
	public RaycastHit hit2;
	public RaycastHit hit3;
	public RaycastHit hit4;
	public man_move m_script = null;
	public GameObject cameraposition2;
	public GameObject cameraposition3;
	// Use this for initialization
	void OnGUI()
	{	if (m_script.craneb == true) {
			GUI.color = Color.red;
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2 - 160, Screen.width/6, Screen.height/5), "남은시간");
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2 - 120, Screen.width/6, Screen.height/5), (30 - timer).ToString ());
		}
	}

	void Start () {
		m_script = GameObject.Find ("Man").GetComponent<man_move> ();

		drop_sec = new Vector3(cube.transform.position.x, this.transform.position.y, cube.transform.position.z);
		this.sc = this.gameObject.AddComponent<AudioSource> ();
		this.sc.clip = this.aclip;
		this.sc.loop = true;
		this.sc.Play ();

	}

	// Update is called once per frame
	void Update () 
	{
		if (m_script.craneb == true) {
			Camera.main.GetComponent<Transform> ().position = cameraposition2.transform.position ;
			Camera.main.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 0, 0); 
			if(Input.GetKey(KeyCode.LeftShift)){
				Camera.main.GetComponent<Transform> ().position = cameraposition3.transform.position ;
				Camera.main.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 90.0f, 0); 
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				Camera.main.GetComponent<Transform> ().position = cameraposition2.transform.position ;
				Camera.main.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 0, 0); 
			}
			timer += Time.deltaTime;
			var d_p_f = speed * Time.deltaTime;
			var ver = Input.GetAxis ("Vertical");
			var hor = Input.GetAxis ("Horizontal");
			if (crane_unlock == true) {
				transform.Translate (Vector3.forward * ver * d_p_f);
				transform.Translate (Vector3.right * hor * d_p_f);	
			}
			if (space_unlock == true) {
				if (Input.GetKeyDown (KeyCode.Space) || timer > 30.0f) {
				

					GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;

					sc.pitch = 1.0f;
					crane_unlock = false;
					space_unlock = false;
					StartCoroutine ("Run");

				}
			}
			if (timer > 25.0f) {
				this.sc.pitch = 3.0f;
			}
		}
	}
	IEnumerator Run()
	{
		timer = 0;
		crane1.transform.Rotate (Vector3.forward *40 );
		crane2.transform.Rotate (Vector3.forward * 40 );
		crane3.transform.Rotate (Vector3.forward * 40 );
		crane4.transform.Rotate (Vector3.forward * 40 );
		while(true)
		{ 
			timer = 0;
			Vector3 crane_vec = crane.transform.position;
			if (Vector3.Distance (crane.transform.position, pointas) < 0.01f)
				break;
			transform.Translate (Vector3.down * Time.deltaTime);
			if (Physics.Raycast (crane_vec, Vector3.down, out hit, 0.1f)) {
				pointas = hit.point;
				break;
			}
			yield return null;
		}
		yield return new WaitForSeconds (1.0f);
		crane1.transform.Rotate (Vector3.forward  * -50 );
		crane2.transform.Rotate (Vector3.forward  * -50 );
		crane3.transform.Rotate (Vector3.forward  * -50 );
		crane4.transform.Rotate (Vector3.forward  * -50 );
		yield return new WaitForSeconds (1.0f);
		while(true)
		{ 
			timer = 0;
			Vector3 crane_vec = craneaa.transform.position;
			transform.Translate (Vector3.up * Time.deltaTime * 0.5f);
			if (Vector3.Distance (crane_vec, pointas2) < 0.01f)
				break;
			if (Physics.Raycast (transform.TransformDirection(crane_vec), transform.TransformDirection(Vector3.up), out hit2, 0.2f)) 
			{
				pointas2 = hit2.point;
				break;
			}
			yield return null;
		}
		yield return new WaitForSeconds (1.0f);

		while(true)
		{ 
			timer = 0;
			Vector3 crane_vec = cranebb.transform.position;
			transform.Translate (Vector3.right * Time.deltaTime * 0.5f);
			if (Physics.Raycast (transform.TransformDirection(crane_vec), transform.TransformDirection(Vector3.right), out hit3, 0.5f)) 
			{
				pointas3 = hit3.point;
				break;
			}
			yield return null;
		}
		yield return new WaitForSeconds (1.0f);

		while(true)
		{ 
			timer = 0;
			Vector3 crane_vec = cranecc.transform.position;
			transform.Translate (Vector3.forward * Time.deltaTime * 0.5f);
			if (Vector3.Distance (crane_vec, pointas4) < 0.01f)
				break;
			if (Physics.Raycast (transform.TransformDirection(crane_vec), transform.TransformDirection(Vector3.forward), out hit4, 0.8f)) 
			{
				pointas4 = hit4.point;
				break;
			}
			yield return null;
		}
		timer = 0;
		yield return new WaitForSeconds (1.0f);
		crane1.transform.Rotate (Vector3.forward *50 );
		crane2.transform.Rotate (Vector3.forward * 50 );
		crane3.transform.Rotate (Vector3.forward * 50 );
		crane4.transform.Rotate (Vector3.forward * 50 );
		timer = 0;
		yield return new WaitForSeconds (1.0f);
		crane1.transform.Rotate (Vector3.forward  * -40 );
		crane2.transform.Rotate (Vector3.forward  * -40 );
		crane3.transform.Rotate (Vector3.forward  * -40 );
		crane4.transform.Rotate (Vector3.forward  * -40 );
		crane_unlock = true;
		space_unlock = true;
		timer = 0;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.FreezePositionY;
	}



}