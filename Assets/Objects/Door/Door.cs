using UnityEngine;
using System.Collections.Generic;

public class Door : MonoBehaviour {
    //References
    public Animator animator;
    private List<Unit> unitsInsideTrigger;

    public bool OpenOnDistance = true;
    public bool OpenWithUse = true;
    public bool OpenWithKey = false;

    void Start ()
    {
        if (!animator) {
            animator = GetComponentInChildren<Animator>();
        }

        unitsInsideTrigger = new List<Unit>();
	}

    void OnTriggerEnter(Collider other)
    {
        Unit unit = other.GetComponent<Unit>();
        if (unit && OpenOnDistance) {
            unitsInsideTrigger.Add(unit);

            if (unitsInsideTrigger.Count > 0)
            {
                animator.SetBool("Opened", true);
                Invoke("OnOpen", 0);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Unit unit = other.GetComponent<Unit>();
        if (unit && OpenOnDistance)
        {
            unitsInsideTrigger.Remove(unit);

            if (unitsInsideTrigger.Count <= 0) {
                animator.SetBool("Opened", false);
                Invoke("OnClose", 0);
            }
        }
    }

    protected void OnOpen() {}
    protected void OnClose() {}
}
