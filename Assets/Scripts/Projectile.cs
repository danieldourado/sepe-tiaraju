using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour 
{

	private Vector3[] path;
	private float progress = 0f;
	private float currentTime;
	private GameObject target;
	private DamageData data;
	private float timeProjectileStaysInAir;
	public GameObject FX;
	public List<AudioClip> sound;
	//private Vector3 lastPos;

	void OnEnable()
	{
		Main.instance.audioManager.PlayAudio(sound);
	}

	void Update () 
	{
		iTween.PutOnPath(gameObject, path, progress);


		this.currentTime += Time.deltaTime;

		progress = currentTime / timeProjectileStaysInAir;

		if(progress >= 1f)
		{
			progress = 1f;

			DealDamage();
			PlayFXIfAvaliable();

			Destroy(gameObject);
		}

		//lastPos = new Vector3(transform.position.x, transform.position.y, 0f);

		//transform.forward =
		//	Vector3.Slerp(transform.forward, GetComponent<Rigidbody2D>().velocity.normalized, Time.deltaTime);
	}

	public void HitTarget (Vector3[] positions, DamageData damageData, GameObject target)
	{
		this.currentTime = 0f;
		this.path = positions;
		this.data = damageData;
		this.target = target;

		transform.position = positions[0];

		timeProjectileStaysInAir = Vector2.Distance(transform.localPosition, path[path.Length-1]);
		timeProjectileStaysInAir = timeProjectileStaysInAir / data.range;
		timeProjectileStaysInAir = timeProjectileStaysInAir * data.maxTimeProjectileStaysInAir;

		LookToTarget();
	}

	void DealDamage ()
	{
		if(target)
		{
			if(data.damage_area == 0)
				DealDamageSingle();
		}
		if(data.damage_area > 0)
			DealDamageArea();
	}

	void DealDamageSingle ()
	{
		target.GetComponent<Health>().TakeDamage(data);
	}

	void DealDamageArea ()
	{
		Vector2 position = new Vector2(transform.position.x, transform.position.y);
		Collider2D[] colliders = Physics2D.OverlapCircleAll(position, data.damage_area*2);

		

		foreach(Collider2D tempCollider in colliders)
		{
			if(tempCollider.GetComponent<EnemyData>() == null) continue;

			Health ed = tempCollider.GetComponent<Health>();
			ed.TakeDamage(data);
		}
	}

	void PlayFXIfAvaliable ()
	{
		if(FX == null) return;

		var tempFX = Instantiate<GameObject>(FX);
		tempFX.GetComponent<ParticleFX>().Play(transform.position);
	}

	void OnDrawGizmosSelected() 
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, data.damage_area*2);
	}

	void LookToTarget()
	{
		Vector3 difference = path[path.Length-1] - transform.position;
		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
	}
}
