using UnityEngine;
using System.Collections;

public class GroundFlag : MonoBehaviour 
{
	public float timeout = 1f;

	public void Start()
	{
		Hide();
	}

	public void SetTarget(Vector3 target)
	{
		target.z = 0f;
		Main.instance.showWithEffect.ShowAtPosition(gameObject,target);
		//transform.position = target;
		Invoke("Hide", timeout);
	}

	void Hide()
	{
		Main.instance.showWithEffect.HideAtDefaultPosition(gameObject);
		//transform.position = new Vector3(-1000f,-1000f);
	}
}
