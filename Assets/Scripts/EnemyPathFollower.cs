using UnityEngine;
using System.Collections;

public class EnemyPathFollower : MonoBehaviour 
{

	EnemyData enemyData;
	Health healthData;
	MoverData moverData;
	void Start () 
	{
		healthData = GetComponent<Health>();
		enemyData = GetComponent<EnemyData>();
		moverData = GetComponent<MoverData>();
		Vector3[] randomPath =  GetRandomPath();
		if(randomPath == null) return;
		transform.position = randomPath[0];
		iTween.MoveTo(gameObject, iTween.Hash("path", randomPath, "speed", moverData.speed, 
		                                      "easetype", iTween.EaseType.linear, "oncomplete", "OnComplete"));
		enemyData.tweenInfo.tween = GetComponent<iTween>();
		enemyData.tweenInfo.startTime = Time.time;
	}
	
	public void Reset()
	{
		Destroy(enemyData.tweenInfo.tween);
		transform.position = GetRandomPath()[0];
	}
	
	void FixedUpdate()
	{
		SetSpeed();
	}
	
	void SetSpeed ()
	{

	}
	
	private Vector3[] GetRandomPath ()
	{
		int seed = Random.Range(1,3);
		Settings.EnemyPath pathName = Settings.EnemyPath.Path1;
		
		switch (seed)
		{
		case 1:
			pathName = Settings.EnemyPath.Path1;
			break;
			
		case 2:
			pathName = Settings.EnemyPath.Path2;
			break;
			
		case 3:
			pathName = Settings.EnemyPath.Path3;
			break;
		}
		
		return iTweenPath.GetPath(pathName.ToString());
	}

	public void OnComplete ()
	{
		GetComponent<EnemyReseter>().Passed();
	}
}
