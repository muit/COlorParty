using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {
	public Vector3 shakeOffset = new Vector3(0.1f, 0.1f, 0.1f);

	void Start () {
	
	}

	void Update () {
		float randNrX = Random.Range(shakeOffset.x,-shakeOffset.x);
		float randNrY = Random.Range(shakeOffset.y,-shakeOffset.y);
		float randNrZ = Random.Range(shakeOffset.z,-shakeOffset.z);
		transform.position += new Vector3(randNrX,randNrY,randNrZ);
	}
}
