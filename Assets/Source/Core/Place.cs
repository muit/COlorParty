using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {
	void Start (){}

    public void Hidden(bool value)
    {
        gameObject.SetActive(!value);
    }
}
