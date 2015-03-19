using UnityEngine;
using System;
using System.Collections.Generic;

public class SceneScript : MonoBehaviour
{
    public List<Phase> phases;
    private Phase actualPhase;
    private Place[] places;

    protected void Start ()
    {
        //Load Places
        places = GetComponentsInChildren<Place>();
        //InitialPhase
        GoPhase(phases[0]);
	}

    protected void Update () {
	
	}

    public void GoPhase(string name) {
        foreach (Phase phase in phases) {
            if (phase.name == name) {
                GoPhase(phase);
                break;
            }
        }
    }

    public void GoPhase(Phase phase)
    {
        CallPhaseEndEvent(actualPhase);
        actualPhase = phase;
        CallPhaseStartEvent(phase);
    }

    private void GoNextPhase() {
        Int16 index = (Int16)(phases.IndexOf(actualPhase)+1);
        if (index >= phases.Count)
            index = 0;
        actualPhase = phases[index];
    }


    private void CallPhaseStartEvent(Phase phase)
    {
        if (phase.name == null || phase.name.Length <= 1) return;
        Invoke("OnStart_" + phase.name, 0);
    }

    private void CallPhaseEndEvent(Phase phase)
    {
        if (phase.name == null || phase.name.Length <= 1) return;
        Invoke("OnEnd_" + phase.name, 0);
    }


    //Places
    public Place FindPlace(string name)
    {
        foreach (Place place in places)
            if (place.name == name)
                return place;
        return null;
    }

}

[System.Serializable]
public struct Phase {
    public string name;
    public Int16 duration;
}
