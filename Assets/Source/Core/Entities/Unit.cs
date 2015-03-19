using UnityEngine;
using System.Collections.Generic;

public enum Team {
	NONE,
	RED,
	BLUE
};

public class Unit : MonoBehaviour {
	public Team team = Team.RED;
	public Stats stats;

	protected Animator animator;
    [System.NonSerialized]
	public Unit target;
	protected CharacterController characterController;

	public virtual void Start ()
    {
		animator = GetComponent<Animator>();
		characterController = GetComponent<CharacterController>();
	}


	public virtual void Update () {}

	public bool IsAlive()
    {
		return stats.IsAlive();
	}

	public void MeleeDamageBy(Unit caster)
    {
		int amount = (int)Mathf.Round(Random.Range(caster.stats.damage*0.80f, caster.stats.damage*1.2f));
		DamageBy(caster, amount);
	}


	public void DamageBy(Unit caster, int amount)
    {
        //Cause damage
        stats.ReceiveDamage(amount);
        caster.stats.CauseDamage(amount);

        //Add dead count if needed
        if(!IsAlive())
            caster.stats.deads++;

        //Control Animations
        if (animator && animator.GetBool("death") == false)
        {
            if (!IsAlive())
                animator.SetBool("death", true);
            else
                animator.SetTrigger("hit");
        }
    }
	
	public void FollowPath(Vector3[] path)
    {
		//Follow path
	}

	public void FollowPath(string pathname)
    {
		//FollowPath (GetPath(pathname));
	}

	public void Despawn(int delay = 0)
    {
		GameObject.Destroy(gameObject, delay/1000);
	}
	
	protected void EnemyDetected(Unit target)
    {
        if (target != null)
            this.target = target.GetComponent<Unit>();
    }
}
