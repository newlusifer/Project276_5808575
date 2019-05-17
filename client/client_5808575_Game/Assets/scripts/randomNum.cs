using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class randomNum : MonoBehaviour {

    public Button button;

    public Text textshow;
    public Text textshow2;

    public static string namePlayer = "";

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    

    // Use this for initialization
    void Start() {
        // button.interactable = false;
        r1.SetActive(true);
        r2.SetActive(false);
        r3.SetActive(false);
        
    }

    // Update is called once per frame
    void Update() {
        networkConnection.socket.On("name", onGetName);
        networkConnection.socket.On("startRoll",OnStartRoll);
        networkConnection.socket.On("wrong", OnWrong);
        networkConnection.socket.On("winner", OnWinner);
    }

    public void startRandom()
    {
        int ranNum = Random.Range(1, 7);
        Debug.Log("number is "+ranNum.ToString());
        JSONObject job = new JSONObject(ranNum);
        JSONObject job2 = new JSONObject(namePlayer);
        networkConnection.socket.Emit("name", job2);
        networkConnection.socket.Emit("roll",job);
        textshow2.text = "yourNumber : "+ranNum;
    }

    public void OnStartRoll(SocketIOEvent e)
    {
        //button.interactable = true;
    }

    public void OnWrong(SocketIOEvent e)
    {
        textshow.text = "that wrong so sad T^T";
        r1.SetActive(false);
        r2.SetActive(false);
        r3.SetActive(true);
       
    }

    public void OnWinner(SocketIOEvent e)
    {
        textshow.text = "The winner is "+e.data.ToString();
        r1.SetActive(false);
        r2.SetActive(true);
        r3.SetActive(false);        
    }

    void onGetName(SocketIOEvent e)
    {
        Debug.Log("connect to server and get name");
        namePlayer = e.data.ToString();
        Debug.Log("my name is " + e.data.ToString());
        textshow.text = "start Roll !!!!";
    }

}
