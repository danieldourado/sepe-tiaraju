using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DuelData))]
[RequireComponent(typeof(MoverData))]
[RequireComponent(typeof(InfoData))]
[RequireComponent(typeof(DamageData))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AllyDuel))]
[RequireComponent(typeof(MoveToPoint))]


public class Warrior : MonoBehaviour 
{
	ReloadTimer reloadTimer;
	Health health;
	public void Start () 
	{
		gameObject.AddComponent<Rigidbody2D>().isKinematic = true;
		gameObject.AddComponent<CircleCollider2D>().isTrigger = true;
		//gameObject.AddComponent<Death>();
		//gameObject.AddComponent<Movement>();
		//gameObject.AddComponent<EnemyReseter>();

		gameObject.AddComponent<Movement>();
		gameObject.AddComponent<GeneralSkin>();
		//gameObject.AddComponent<MoveToPoint>();

		health = GetComponent<Health>();
	}
}
