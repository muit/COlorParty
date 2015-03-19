using UnityEngine;
using System.Collections;

public class Game{
	public static GameController gc;
	public static GameController GetGc(){
		if(!gc)
			return gc = GameObject.Find("GameManager").GetComponent<GameController>();
		return gc;
	}

    public static SceneScript scene;
    public static SceneScript GetScene()
    {
        if (!scene)
            return scene = GameObject.Find("Scene").GetComponent<SceneScript>();
        return scene;
    }

    public static void Start(){
	}

	public static void End(){
	}
}
