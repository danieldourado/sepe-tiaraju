using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
	float originalWidth;
	RectTransform bar;

	Health data;

	public GameObject redBar, greenBar;

	public void SetData(Health data)
	{
		this.data = data;

		SetSize();

		originalWidth = greenBar.GetComponent<RectTransform>().sizeDelta.x;
		bar = greenBar.GetComponent<RectTransform>();

	}

	void SetSize ()
	{

	}

	void Update () 
	{
		UpdatePosition();
		UpdateProgress();
	}

	void UpdatePosition ()
	{
		Vector3 newPosition = data.gameObject.transform.position;
		newPosition.y += 30f;
		transform.position = newPosition;
	}

	void UpdateProgress ()
	{
		float progress = data.currentHealth / data.startHealth;

		if(progress == 0f)SetBarsActive(false);
		else SetBarsActive(true);

		bar.sizeDelta = new Vector2(originalWidth * progress, bar.sizeDelta.y);
	}

	void SetBarsActive (bool state)
	{
		redBar.SetActive(state);
		greenBar.SetActive(state);
	}
}
