using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class networkConnection : MonoBehaviour {

   public static SocketIOComponent socket;

   

	// Use this for initialization
	void Start () {
        socket = GetComponent<SocketIOComponent>();

       // socket.On("yourname", onGetName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   // void onGetName(SocketIOEvent e)
   // {
   //     Debug.Log("connect to server and get name");
   //     namePlayer = e.data.ToString();
  //      Debug.Log("my name is "+e.data.ToString());

   // }
}
