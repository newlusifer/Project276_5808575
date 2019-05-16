using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class networkConnection : MonoBehaviour {

    static SocketIOComponent socket;

	// Use this for initialization
	void Start () {
        socket = GetComponent<SocketIOComponent>();

        socket.On("hello", onHello);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onHello(SocketIOEvent e)
    {
        Debug.Log("connect to server");
        socket.Emit("say");
    }
}
