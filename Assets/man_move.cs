using UnityEngine;
using System.Collections;

public class man_move : MonoBehaviour {
	public GameObject head;
	Vector3 Rot;
	public bool man=true;
	public bool pushb=false;
	public bool craneb=false;
	public GameObject camerap= null;
	// Use this for initialization
	void Start () {
		
	}
	void OnCollisionEnter(Collision coll)
	{
		GameObject go = coll.gameObject;
		if (go.tag == "pushcoll") {
			Debug.Log ("충돌");
			if(Input.GetKey(KeyCode.Q)){
				pushb = true;
				man = false;
			}
		}
		if (go.tag == "cranecoll") {
			Debug.Log ("충돌");
			if(Input.GetKey(KeyCode.Q)){
				craneb = true;
				man = false;

			}
		}
	
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			man = true;
			craneb = false;
			pushb = false;
			Camera.main.GetComponent<Transform> ().position = camerap.transform.position ;
		}
		if (man == true) {
			transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * 5 * Time.deltaTime);
			transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * 5 * Time.deltaTime);
			transform.Rotate (Vector3.up * Input.GetAxis ("Mouse X") * 30 * Time.deltaTime);
			head.transform.Rotate (Vector3.left * Input.GetAxis ("Mouse Y") * 15 * Time.deltaTime);


			Rot = Camera.main.GetComponent<Transform> ().eulerAngles;
			if (Rot.x >= 180f && Rot.x <= 360f) {
				if (Rot.x <= 360 - 45)
					Rot.x = 360 - 45;
			}
			if (Rot.x >= 0f && Rot.x <= 180f) {
				if (Rot.x >= 45)
					Rot.x = 45;
			}
			Camera.main.GetComponent<Transform> ().eulerAngles = Rot;

		}
	}
}
