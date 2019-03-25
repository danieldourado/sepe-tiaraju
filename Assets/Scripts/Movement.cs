using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public enum Direction
	{
		Left,
		Right,
		Up,
		Down,
		None
	}

	public Direction direction;
	private TravelData travelData;
	private MoverData moverData;
	private DuelData duelData;
	private Health healthData;

	void Start () 
	{
		travelData = new TravelData();
		moverData = GetComponent<MoverData>();
		duelData = GetComponent<DuelData>();
		healthData = GetComponent<Health>();
	}


	void Update()
	{
		CheckIfShouldStop();
		CalculateTravelData();
		SetDirection();
	}

	void SetDirection ()
	{
		Vector3 difference = travelData.difference;
		Vector3 positiveDifference = new Vector3();
		
		if(difference.x < 0f) positiveDifference.x = difference.x*-1;
		else positiveDifference.x = difference.x;
		if(difference.y < 0f) positiveDifference.y = difference.y*-1;
		else positiveDifference.y = difference.y;
		if(difference.z < 0f) positiveDifference.z = difference.z*-1;
		else positiveDifference.z = difference.z;
		
		if(positiveDifference.x > positiveDifference.y)
		{
			if(difference.x < 0f) direction = Direction.Right;
			else direction = Direction.Left;
		}
		else
		{
			if(difference.y < 0f) direction = Direction.Up;
			else direction = Direction.Down;
		}
		if((positiveDifference.x == 0f) &&(positiveDifference.y ==0f))
		{
			direction = Direction.None;
		}
		//m_LastPosition = transform.position;
		
		moverData.direction = direction;
		if(direction == Direction.None)
		{
			moverData.isMoving = false;
		}
		else
		{
			moverData.isMoving = true;
		}
	}


	void CalculateTravelData ()
	{
		travelData.difference = travelData.m_LastPosition - transform.position;
		travelData.time = Time.fixedDeltaTime;
		travelData.m_LastPosition = transform.position;
		moverData.travel = travelData;
	}

	void CheckIfShouldStop ()
	{
		if((duelData.isOnDuel)||(healthData.currentHealth <=0f))
		{
			iTween.Pause(gameObject);
		}
		else
		{
			iTween.Resume(gameObject);
		}
	}

}

public class EnemyTween
{
	public iTween tween;
	public float startTime;
}

public class TravelData
{
	public Vector3 m_LastPosition;
	public float time;
	public Vector3 difference;
}
