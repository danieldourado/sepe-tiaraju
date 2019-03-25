using UnityEngine;
using System.Collections;

public class TouchOrganizer : MonoBehaviour 
{
	private BuildTowerMenu btm;
	private TowerMenu tm;
	private TowerRangeCircle towerRangeCircle;
	private Hero hero;
	private Reinforcements reinforcements;
	private SpecialHability[] sh1;

	void Start()
	{
		btm = FindObjectOfType<BuildTowerMenu>();
		towerRangeCircle = FindObjectOfType<TowerRangeCircle>();
		tm = FindObjectOfType<TowerMenu>();
		hero = FindObjectOfType<Hero>();
		reinforcements = FindObjectOfType<Reinforcements>();
		sh1 = FindObjectsOfType<SpecialHability>();
	}

	public void Hide()
	{
		Start();
		if(btm)	btm.Hide();
		if(towerRangeCircle)towerRangeCircle.Hide();
		if(tm)tm.Hide ();
		if(hero)hero.Hide();
		if(reinforcements)reinforcements.Hide();
		if(sh1 != null)
		{
			foreach(SpecialHability sp in sh1)
			{
				sp.Hide();
			}
		}
	}
}
