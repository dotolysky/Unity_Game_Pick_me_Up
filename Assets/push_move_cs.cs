using UnityEngine;
using System.Collections;
using System.Threading;

public class push_move_cs : MonoBehaviour {
	public bool move_lock=true;
	public bool push_lock=false;
	public float cnt =0;
	public GameObject crane;
	public GameObject pushbar;
	RaycastHit hit;
	public int i=0;
	Vector3 pointas;
	Vector3 pointas1;
	public Vector3 pbposition;
	public Vector3 pbposition2;
	public GameObject cameraposition;

	public man_move m_script = null;
	// Use this for initialization
	void Start () {
		m_script = GameObject.Find ("Man").GetComponent<man_move> ();

		move_lock=true;
		push_lock=false;
		pbposition = transform.position;
		pbposition2 = pushbar.transform.position;
	}

	// Update is called once per frame
	void Update ()
	{

		if (m_script.pushb == true) {
			Camera.main.GetComponent<Transform> ().position = cameraposition.transform.position ;
			Camera.main.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 0, 0); 
			if (move_lock == true) {
				if (Input.GetKey (KeyCode.RightArrow)) {
					this.transform.Translate (Vector3.right * 0.5f * Time.deltaTime);
				}
				if (Input.GetKeyUp (KeyCode.RightArrow)) {
					move_lock = false;
					push_lock = true;
				}
				if (this.transform.position.x > 1.7f) {
					move_lock = false;
					push_lock = true;
				}
			}
			if (push_lock == true) {

				if (Input.GetKey (KeyCode.Space)) {
					this.transform.Translate (Vector3.up * 0.5f * Time.deltaTime);
				}

				if (Input.GetKeyUp (KeyCode.Space)) {
					push_lock = false;
					StartCoroutine ("down");
				}
			}
		}
	}
	void pui()
	{
		while(i<=298){
			pushbar.GetComponent<Rigidbody>().AddForce(Vector3.forward);
			i++;
		}
	}
	void puo()
	{
		while(i>=0){
			pushbar.GetComponent<Rigidbody>().AddForce(Vector3.back);
			i--;
		}
	}
	void comeback(){
		transform.position = pbposition;
		pushbar.transform.position = pbposition2;
		move_lock = true;

	}
	IEnumerator down()
	{
		pui ();
		yield return new WaitForSeconds (1.0f);
		puo ();
		yield return new WaitForSeconds (2.0f);
		while (true) 
		{
			Vector3 crane_vec = crane.transform.position;
			if (Vector3.Distance (crane.transform.position, pointas) < 0.1f)
				break;
			transform.Translate (Vector3.down * Time.deltaTime * 0.5f);
			if (Physics.Raycast (transform.TransformDirection(crane_vec), transform.TransformDirection(Vector3.down), out hit, 0.1f)) {
				Debug.Log (Physics.Raycast (crane_vec, Vector3.down, out hit, 0.001f));
				pointas = hit.point;
				break;
			}   
			yield return null;
		}
		yield return new WaitForSeconds (0.5f);
		while (true) 
		{
			Vector3 crane_vec = crane.transform.position;
			if (Vector3.Distance (crane_vec, pointas1) < 0.4f)
				break;
			transform.Translate (Vector3.left * Time.deltaTime * 0.4f);
			if (Physics.Raycast (crane_vec, Vector3.left, out hit, 0.4f)) 
			{
				Debug.Log (Physics.Raycast (crane_vec, Vector3.left, out hit, 0.4f));
				pointas1 = hit.point;
				break;
			}
			yield return null;
		}
		yield return new WaitForSeconds (0.5f);
		comeback ();
	}

}