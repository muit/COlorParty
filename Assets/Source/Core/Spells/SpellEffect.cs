using UnityEngine;
using System;
using System.Collections.Generic;

public enum Effects {
	TOWER_FIRE = 0
}

public class SpellEffect : MonoBehaviour {
	public int despawnTimer = 0;
	public bool useCasterPosition = true;
	public Vector3 orUsePosition = Vector3.zero;

	protected Unit caster;

	void Start () {
		if(despawnTimer > 0) Despawn(despawnTimer);
	}

	public virtual void Load(Unit caster){
		this.caster = caster;
	}

	void Update () {
	
	}

	public void Despawn(int delay = 0){
		GameObject.Destroy(gameObject, delay/1000);
    }

    /*
	public static SpellEffect New(int id, Unit caster){
		SpellEffect prefab = Game.gc.effectDictionary[id];
		if(prefab == null)
			Debug.LogError("This Effect does not exist.");
		Vector3 position = prefab.orUsePosition;
		if(prefab.useCasterPosition){
			Transform targetPosition = caster.transform.FindChild("TargetPosition");
			if(targetPosition == null) targetPosition = caster.transform;
			position = targetPosition.position;
		}

		Transform effectTrans = Instantiate(prefab.transform, position, prefab.transform.rotation) as Transform;
		effectTrans.parent = caster.transform;
		SpellEffect effect = effectTrans.GetComponent<SpellEffect>();

		if(effect == null)
			Debug.LogError("Error creating effect.");
		effect.Load(caster);
		return effect;
	}
    */
}
