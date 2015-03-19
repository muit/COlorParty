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
