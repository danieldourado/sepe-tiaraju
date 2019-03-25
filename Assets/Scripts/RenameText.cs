using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class RenameText : MonoBehaviour 
{
	void Starte() 
	{
	 	var levelName = GetComponent<Level>().level.ToString();
		GetComponentInChildren<Text>().text = levelName;
		//Debug.Log(levelName);
		
	}
	void Update()
	{
		Starte();
	}
}
