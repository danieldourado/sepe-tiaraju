using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileRain : MonoBehaviour 
{
	public GameObject projectilePrefab;
	public int quantidadeDeProjeteis = 5;
	public int distanciaEntreProjeteis = 50;
	public float intervaloEntreProjeteis = 0.01f;

	List<GameObject> instances;

	void Start () 
	{
		CreateInstances();
	}

	void CreateInstances ()
	{
		for(int i =1; i<=quantidadeDeProjeteis; i++)
		{
			Invoke("DoInstantiate", intervaloEntreProjeteis*i);
		}
	}

	void DoInstantiate()
	{
		var newInstance = Instantiate<GameObject>(projectilePrefab);
		//instances.Add(newInstance);
		var data = GetComponent<DamageData>();
		newInstance.GetComponent<Projectile>().HitTarget(GeneratePath(), data, null);
	}

	Vector3[] GeneratePath ()
	{
		var initialPos = new Vector3(transform.position.x, 2100f, 0f);
		var targetPos =  transform.position;
		
		Vector3[] positions = new Vector3[2];
		positions[0] = initialPos;
		
		Vector3 middlePoint = new Vector3();
		
		middlePoint.x = (initialPos.x + targetPos.x)/2;
		middlePoint.y = (initialPos.y + targetPos.y)/2;

		targetPos.x += Random.Range(-distanciaEntreProjeteis, distanciaEntreProjeteis);
		targetPos.y += Random.Range(-distanciaEntreProjeteis, distanciaEntreProjeteis);


		//positions[1] = middlePoint;
		positions[1] = targetPos;

		return positions;
	}
}
