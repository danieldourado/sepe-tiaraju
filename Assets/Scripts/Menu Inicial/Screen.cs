using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour 
{

	public Vector3 hidePos = new Vector3(-1920f, -1080f);
	public Vector3 showPos = new Vector3(0f,0f);

	void Awake()
	{
		HideNoEffect();
	}
	
	public void Show () 
	{
		ShowWithScaleEffect();
	}	

	public void ShowWithScaleEffect () 
	{
		Main.instance.showWithEffect.ShowAtPosition(gameObject, showPos);
	}

	public void ShowNoEffect () 
	{
		transform.position = showPos;
	}
	
	public void Hide () 
	{
		HideWithScaleEffect () ;
	}
	public void HideWithScaleEffect () 
	{
		Main.instance.showWithEffect.HideAtDefaultPosition(gameObject);
	}

	public void HideNoEffect () 
	{
		transform.position = hidePos;
	}
}
