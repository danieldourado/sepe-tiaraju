using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour 
{
	GameObject healthBarGO;

	public GameObject redBar, greenBar;
	
	void Start()
	{
		healthBarGO = Instantiate(Resources.Load("UI/HealthBar")) as GameObject;
		healthBarGO.GetComponent<HealthBar>().SetData(GetComponent<Health>());
		healthBarGO.transform.SetParent(transform);
	}
}
