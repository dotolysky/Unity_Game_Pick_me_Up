using UnityEngine;
using System.Collections;

public class catch_cs : MonoBehaviour {
	public GameObject spp = null;
	static int cnt=0;
	public man_move m_script = null;

	int size = 20;
	// Use this for initialization
	void Start () {
		m_script = GameObject.Find ("Man").GetComponent<man_move> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
			Debug.Log (Input.mousePosition);
	}

	void OnGUI()
	{
		if (m_script.pushb == true) {
			GUI.skin.label.fontSize = size;
			GUI.color = Color.black;
			GUI.Label (new Rect (Screen.width - 100, Screen.height - 100, Screen.width/6, Screen.height/5), "획득 개수");
			GUI.Label (new Rect (Screen.width - 80, Screen.height - 60, Screen.width/6, Screen.height/5), cnt.ToString ());
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		GameObject go = coll.gameObject;
		if (go.tag == "Box") {
			go.transform.position = spp.transform.position;
			cnt++;
		}

	}
}
