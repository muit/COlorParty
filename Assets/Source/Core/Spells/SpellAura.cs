using UnityEngine;
using System.Collections;


public enum Debuffs {
}

public class SpellAura: MonoBehaviour {
    private Unit me;

	// Use this for initialization
	void Start () {
        me = gameObject.GetComponent<Unit>();
        if (!me) {
            Debug.Log("The Aura needs to be applied to a Unit.");
            Destroy(this);
            return;
        }


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
