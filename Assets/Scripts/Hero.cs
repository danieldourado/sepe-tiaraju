using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Warrior))]
public class Hero : MonoBehaviour 
{
	public enum HeroID
	{
		sepeLvl1,
		sepeLvl2,
		sepeLvl3,
		sepeLvl4,
		juremaLvl1,
		juremaLvl2,
		juremaLvl3,
		juremaLvl4,
		jesuitaLvl1,
		jesuitaLvl2,
		jesuitaLvl3,
		jesuitaLvl4,
		xamaLvl1,
		xamaLvl2,
		xamaLvl3,
		xamaLvl4,
		neenguiruLvl1,
		neenguiruLvl2,
		neenguiruLvl3,
		neenguiruLvl4
	}

	public HeroID heroID;
	public Sprite heroSprite;

	[HideInInspector]
	public bool isSelected;

	public void Start () 
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
	}

	private void CheckEvent(GameEvent ge)
	{
		if(ge == GameEvent.HeroSelected) HeroSelectedHandler();
	}

	void HeroSelectedHandler ()
	{
		if(isSelected)
		{
			FindObjectOfType<TouchOrganizer>().Hide();
		}
		else
		{
			FindObjectOfType<TouchOrganizer>().Hide();
			isSelected = true;
			Debug.Log("Hero Selected");
			Main.instance.audioManager.PlayAudio(GetComponent<InfoData>().clickSound);
		}
	}

	public void Hide ()
	{
		if(isSelected)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			FindObjectOfType<GroundFlag>().SetTarget(target);

			target.z = transform.position.z;
			GetComponent<AllyDuel>().CancelDuel();
			GetComponent<MoveToPoint>().SetTarget(target);
		}

		isSelected = false;
		Debug.Log("Hero deSelected");
	}

	void Update()
	{

		var health = GetComponent<Health>();
		if(health.isDead)
		{
			if(!GetComponent<Resuscitate>())
			{
				gameObject.AddComponent<Resuscitate>();
			}
		}
	}

	void OnDestroy()
	{
		GameStateManager.OnGameEventChanged -= CheckEvent;
	}
}
