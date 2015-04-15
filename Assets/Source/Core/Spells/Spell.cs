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

public struct Spells {
    public const string EMPTY = "",
    CREEP_HIT = "Spell_Creep_Hit",
    TOWER_FIRE = "Spell_Tower_Fire";
}

public class Spell {
    public int guid = -1;
    public int spellMinDamage = 0;
    public int spellMaxDamage = 0;

	public Spell(){}

    public virtual void Update(){}
    
    public virtual void Cast(Unit caster, Unit victim){}

    public void Remove(){
        Spell.Remove(this);
    }

	public string GetId(){
		return this.GetType().Name;
	}





    /**Static Spell Class**/

    public static void Start(){
        spellCache = new SpellCache();
    }
    public static void FixedUpdate(){
        foreach(Spell spell in spellCache)
            spell.Update();
    }

    //Cast Spell
	public static Spell Cast(Unit caster, Unit victim, string spellId){
        Spell spell = Activator.CreateInstance(Type.GetType(spellId)) as Spell;
        Add(spell);
		spell.Cast(caster, victim);
        return spell;
	}

    //SpellCache Methods
    public class SpellCache : List<Spell> {}
	public static SpellCache spellCache;
	public static void Add(Spell spell){
		spellCache.Add(spell);
        spell.guid = spellCache.IndexOf(spell);
	}
	public static Spell Get(int guid){
		return spellCache[guid];
	}
    public static void Remove(Spell spell){
        spellCache.Remove(spell);
    }
}
