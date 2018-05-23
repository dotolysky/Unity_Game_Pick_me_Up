using UnityEngine;
using System.Collections;

public class audio : MonoBehaviour {

	private AudioSource audio1;
	public AudioClip bounce_sound;

	// Use this for initialization
	void Start () {
		this.audio1 = this.gameObject.AddComponent<AudioSource> ();
		this.audio1.clip = this.bounce_sound;
		this.audio1.loop = true;
		this.audio1.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
