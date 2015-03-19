using UnityEngine;
using System.Collections;

public class SpellEffect_Follow : SpellEffect {
	private Unit target;
	public int damage = 0;
	public float speed = 10f;
	public float reachRange = 0.4f;

	public void Load(Unit caster, Unit target){
		this.caster = caster;
		this.target = target;
	}

	void FixedUpdate () {
		if(target == null || !target.IsAlive()) {
			Despawn(0);
			return;
		}
		if(Vector3.Distance(target.transform.position, transform.position) > reachRange){
			transform.LookAt(target.transform.position);
			transform.position += transform.forward * speed * Time.deltaTime;
		}else{
			target.DamageBy(caster, 20);
			Despawn(0);
		}
	}

    /*
	public static SpellEffect_Follow New(int id, Unit caster, Unit target){
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
		SpellEffect_Follow effect = effectTrans.GetComponent<SpellEffect_Follow>();

		if(effect == null)
			Debug.LogError("This Effect is not a Follower.");
		effect.Load(caster, target);
		return effect;
	}
    */
}
