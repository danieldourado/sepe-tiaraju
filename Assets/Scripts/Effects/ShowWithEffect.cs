using UnityEngine;
using System.Collections;

public class ShowWithEffect : MonoBehaviour 
{
	public float TIME = 0.2f;
	private Vector3 defaultHidePosition = new Vector3(-1920f, -1080f);
	
	public enum Effect
	{
		Fade,
		Scale
	}
	
	public void ShowAtPosition(GameObject go ,Vector3 position, Effect effect = Effect.Scale)
	{
		go.transform.position = position;
		
		if(effect == Effect.Scale)
			ShowWithScaleEffect(go);
		if(effect == Effect.Fade)
			ShowWithFadeEffect(go);
	}
	
	void ShowWithScaleEffect(GameObject go)
	{
		go.transform.localScale = Vector3.zero;
		iTween.ScaleTo(go, new Vector3(1f,1f,1f), TIME);
	}
	
	void ShowWithFadeEffect(GameObject go)
	{
		iTween.FadeFrom(go, 0f, TIME*3);
	}

	public void HideAtDefaultPosition(GameObject go, Effect effect = Effect.Scale)
	{
		currentHiding = go;
		if(effect == Effect.Scale)
			HideWithScaleEffect();
		if(effect == Effect.Fade)
			HideWithFadeEffect();
	}

	GameObject currentHiding;
	void HideWithScaleEffect()
	{
		iTween.ScaleTo(currentHiding, new Vector3(0f,0f,0f), TIME);
		
		Invoke("MoveToDefaultPosition", TIME);
	}

	void HideWithFadeEffect()
	{
		iTween.FadeTo(currentHiding, 0f, TIME);
		
		Invoke("MoveToDefaultPosition", TIME);
	}

	void MoveToDefaultPosition()
	{
		currentHiding.transform.position = defaultHidePosition;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
