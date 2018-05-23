using UnityEngine;
using System.Collections;

public class catch_crane : MonoBehaviour {
	public Texture2D[] icon = { null, null, null, null, null, null };
	public int[] icon_cnt = {0,0,0,0,0,0};
	public GameObject sec;
	public man_move m_script = null;
	// Use this for initialization
	void Start () {
		m_script = GameObject.Find ("Man").GetComponent<man_move> ();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnGUI()
	{
		if (m_script.craneb == true) {
			GUI.color = Color.black;
			GUI.Label (new Rect (0, Screen.height / 2 + 60, Screen.width/6, Screen.height/5), "획득 개수");
			GUI.Label (new Rect (0, Screen.height / 2 + 140, Screen.width/6, Screen.height/5), "획득 개수");
			for (int i = 1; i <= 3; i++) {
				GUI.color = Color.black;
				GUI.Label (new Rect (54 + 40 * i, Screen.height / 2 + 60, Screen.width/25, Screen.height/20), icon_cnt [i - 1].ToString ());
				GUI.color = Color.white;
				GUI.DrawTexture (new Rect (40 + 40 * i, Screen.height / 2 + 20, Screen.width/25, Screen.height/20), icon [i - 1]);
			}
			for (int i = 1; i <= 3; i++) {
				GUI.color = Color.black;
				GUI.Label (new Rect (54 + 40 * i, Screen.height / 2 + 140, Screen.width/25,Screen.height/20), icon_cnt [i + 2].ToString ());
				GUI.color = Color.white;
				GUI.DrawTexture (new Rect (40 + 40 * i, Screen.height / 2 + 100, Screen.width/25, Screen.height/20), icon [i + 2]);
			}
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		GameObject go = coll.gameObject;
		if (go.tag == "pa") {
			go.transform.position = sec.transform.position;
			icon_cnt [0]++;
		} else if (go.tag == "ma") {
			go.transform.position = sec.transform.position;
			icon_cnt [1]++;
		} else if (go.tag == "pi") {
			go.transform.position = sec.transform.position;
			icon_cnt [2]++;
		} else if (go.tag == "go") {
			go.transform.position = sec.transform.position;
			icon_cnt [3]++;
		} else if (go.tag == "za") {
			go.transform.position = sec.transform.position;
			icon_cnt [4]++;
		} else if (go.tag == "ko") {
			go.transform.position = sec.transform.position;
			icon_cnt [5]++;
		}
	}
}