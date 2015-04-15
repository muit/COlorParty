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
