using UnityEngine;
using System.Collections;

public class TowerBuildingSite : MonoBehaviour 
{
	private BuildTowerMenu btm;

	public void Awake()
	{
		btm = GameObject.FindObjectOfType<BuildTowerMenu>();
		gameObject.AddComponent<TouchDetector2D>().Setup(60f, gameObject);
	}

	public void OnClick()
	{
		btm.ShowMenuAtPosition(transform.position, gameObject);
	}

	public void DisableTouch()
	{
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
	}

	public void EnableTouch()
	{
		gameObject.GetComponent<CircleCollider2D>().enabled = true;
	}


}
