/** SpellSystem
 * 
 * The MIT License (MIT)
 * 
 * Copyright (c) 2015 @muitxer
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
**/
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
