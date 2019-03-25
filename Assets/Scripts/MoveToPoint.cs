using UnityEngine;
using System.Collections;

public class MoveToPoint : MonoBehaviour
{
	float speed = 1.5f;

	public Vector3 target;
	
	void Start () 
	{
		if(target == Vector3.zero) target = transform.position;
		speed = GetComponent<MoverData>().speed;
	}

	public void SetTarget(Vector3 target, bool isDuel = false)
	{
		GetComponent<DuelData>().isMovingToDuel = isDuel;
		GetComponent<MoverData>().isMoving = true;
		this.target = target;
		Update();
	}

	public void Stop()
	{
		this.target = transform.position;
	}

	void Update () 
	{
		if(GetComponent<Health>().isDead) return;
		if(transform.position != target)
		{
			GetComponent<MoverData>().isMoving = true;
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		}
		else
		{
			GetComponent<MoverData>().isMoving = false;
		}

	}    
}
