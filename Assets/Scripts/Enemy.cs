using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyData))]
[RequireComponent(typeof(DuelData))]
[RequireComponent(typeof(MoverData))]
[RequireComponent(typeof(InfoData))]
[RequireComponent(typeof(DamageData))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour 
{
	public void Start () 
	{
		gameObject.AddComponent<Rigidbody2D>().isKinematic = true;
		gameObject.AddComponent<CircleCollider2D>().isTrigger = true;
		GetComponent<CircleCollider2D>().radius = 30f;
		//gameObject.AddComponent<Death>();
		gameObject.AddComponent<EnemyPathFollower>();
		gameObject.AddComponent<EnemyDuel>();
		gameObject.AddComponent<Movement>();
		gameObject.AddComponent<EnemyReseter>();
		gameObject.AddComponent<GeneralSkin>();
		gameObject.AddComponent<EnemyKillCounter>();
		gameObject.AddComponent<ObjectToPool>().Setup(ObjectToPool.Type.Enemy);

		var shooterGO = new GameObject();
		shooterGO.transform.SetParent(transform);
		shooterGO.AddComponent<EnemyShooter>().Setup(GetComponent<DamageData>(), GetComponent<DuelData>());


	}
	
}
