using UnityEngine;
using System.Collections;

public class size : MonoBehaviour {

	private SpriteRenderer _mySpirteRender;


	private static Vector3 screenTo3D(float x2, float y2, float z) {

		return Camera.main.ScreenToWorldPoint (new Vector3(x2, y2, z));
	}



	public static Rect bound3D(float z) {

		Vector3 leftBottom = screenTo3D (0, 0, z);
		Vector3 rightTop = screenTo3D (Camera.main.pixelWidth, Camera.main.pixelHeight, z);
		return new Rect (

			leftBottom.x, rightTop.y,
			rightTop.x - leftBottom.x, rightTop.y - leftBottom.y
		);

	}
	public static Vector3 FullSizeSprite(Vector3 scale, SpriteRenderer render, Rect bound) 
	{

		Vector3 fullScale = Vector3.zero;
		float scaleX, scaleY, scaleZ;

		scaleX = scale.x * (bound.size.x / render.bounds.size.x);
		scaleY = scale.y * (bound.size.y / render.bounds.size.y);
		scaleZ = 1.0f;
		fullScale = new Vector3 (scaleX, scaleY, scaleZ);
		return fullScale;
	}


	void Start() {

		Rect bound = size.bound3D (-Camera.main.transform.position.z);
		_mySpirteRender = GetComponent<SpriteRenderer>();
		transform.localScale = size.FullSizeSprite (transform.localScale, _mySpirteRender, bound);
	}
		
	
	// Update is called once per frame
	void Update () {
	
	}
}
