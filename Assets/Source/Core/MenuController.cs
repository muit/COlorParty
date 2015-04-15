using UnityEngine;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	public string name;

	public GameObject login;

    public Canvas mainMenu;
    public List<Canvas> subMenus = new List<Canvas>();


    // Use this for initialization
    void Start () {
		if(!login) login = GameObject.Find("Canvas/Login");
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

    public void ShowMainMenu()
    {
        HideSubMenus();
        mainMenu.gameObject.SetActive(true);
    }

    public void ShowSubMenu(int id)
    {
        mainMenu.gameObject.SetActive(false);
        Canvas subMenu = subMenus[id];
        if (subMenu)
            subMenu.gameObject.SetActive(true);
    }

    public void HideSubMenus() {
        foreach (Canvas subMenu in subMenus)
            subMenu.gameObject.SetActive(false);
    }


    public void LoadScene(int id)
    {
        Application.LoadLevel(id);
    }

    public void Quit() {
        Application.Quit();
    }
}
