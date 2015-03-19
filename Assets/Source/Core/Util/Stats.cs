using UnityEngine;
using System;

[Serializable]
public class Stats {
	public int health = 100;
	public int maxHealth = 100;
	public int damage = 5;
	public int xp = 0;

	public int kills;
	public int assistences;
	public int deads;
	public int killedCreeps;
	public int damageCaused;
	public int damageReceived;

	public bool IsAlive(){
		bool result = health > 0;
		if(!result) health = 0;
		return result;
	}

	public void ReceiveDamage(int amount){
		health -= amount;
		IsAlive();
		damageReceived += amount;
	}

	public void CauseDamage(int amount){
		damageCaused += amount;
	}

	public void AddXP(int amount){
		xp += amount;
	}

	public int getLevel(){
		return 0;
	}
	public int getLevelXP() {
		return 0;
	}
}
