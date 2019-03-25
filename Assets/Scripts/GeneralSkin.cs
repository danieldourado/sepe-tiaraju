using UnityEngine;
using System.Collections;

public class GeneralSkin : MonoBehaviour 
{
	private Vector3 mirroredScale = new Vector3(-1f, 1f,1f);
	private Vector3 notMirroredScale = new Vector3(1f, 1f,1f);
	private bool mirrored;

	private string STATE = "state";
	private Animator animator;
	private MoverData moverData;
	private Health healthData;
	private DuelData duelData;
	private bool isEnemy;

	void Start () 
	{
		healthData = GetComponent<Health>();
		moverData = GetComponent<MoverData>();
		animator = GetComponentInChildren<Animator>();
		duelData = GetComponent<DuelData>();
		isEnemy = GetComponent<AllyDuel>() == null;
	}

	void Update () 
	{
		if(animator == null) return;
		int state = 0;

		switch(moverData.direction)
		{
		case Movement.Direction.Right:
			state = 1;
			mirrored = false;
			break;

		case Movement.Direction.Left:
			state = 1;
			mirrored = true;
			break;

		case Movement.Direction.Up:
			state = 2;
			break;
			
		case Movement.Direction.Down:
			state = 3;
			break;
		
		case Movement.Direction.None:
			state = 6;
			break;
		}

		if(duelData.canAttack)
		{
			state = 5;
			mirrored = !isEnemy;
		}

		if(healthData.currentHealth <= 0) state = 4;

		if(state == 5)
		{
			animator.SetInteger(STATE, 7);
		}
		else
		{
			animator.SetInteger(STATE, state);
		}

		if(mirrored)
		{
			transform.localScale = mirroredScale;
		}
		else
			transform.localScale = notMirroredScale;

	}
}
