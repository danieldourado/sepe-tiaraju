using UnityEngine;
using System.Collections;

public class ShowScreenAtStart : MonoBehaviour {

	public GameObject screen;
	void Start () {
		screen.SendMessage("Show");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
