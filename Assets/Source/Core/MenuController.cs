using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public string name;

	public GameObject login;

	// Use this for initialization
	void Start () {
		if(login == null) login = GameObject.Find("Canvas/Login");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Login(string username){
		name = username;
		login.SetActive(false);
		Debug.Log ("Logged as "+name);
	}

	public void GetAndLogin(){
		GameObject nameInput = GameObject.Find("NameInputValue");
		//Login(nameInput.GetComponent<UIInput>().text);
	}
}
