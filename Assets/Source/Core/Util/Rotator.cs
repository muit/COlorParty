using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	//udateis called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (0, 10, 0) * Time.deltaTime);
	}
}
