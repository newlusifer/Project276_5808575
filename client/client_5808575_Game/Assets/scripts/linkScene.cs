using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class linkScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("game");
    }

    public void OnHowTo()
    {
        SceneManager.LoadScene("howTo");
    }

    public void OnBack()
    {
        SceneManager.LoadScene("main");
        networkConnection.socket.Close();
    }
}
