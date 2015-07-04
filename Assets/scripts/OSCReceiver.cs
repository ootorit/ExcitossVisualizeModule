using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OSCReceiver : MonoBehaviour {
	
	public string RemoteIP = "127.0.0.1";
	public int SendToPort = 9000;
	public int ListenerPort = 12345;
	public Transform controller;
	private Osc handler;

	// Use this for initialization
	void Start () {
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(RemoteIP, SendToPort, ListenerPort);
		handler = GetComponent<Osc>();
		handler.init(udp);

		handler.SetAddressHandler("/test", Cry);
		Debug.Log("Running");
	}

	public void Cry (OscMessage oscMessage) {
		Debug.Log("Called Example Two > " + Osc.OscMessageToString(oscMessage));
		Debug.Log("Message Values > " + oscMessage.Values[0]);	
	}

	void update(){
	}
}