using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public float startHealth = 100f;
	public float timeToResuscitate = 5f;
	public float currentHealth = 0f;
	public bool isDead;
	public float renenerationPerSecond = 0f;
	public int armor = 0;

	public void Start()
	{
		currentHealth = startHealth;
		isDead = false;

		if(!gameObject.GetComponent<GeneralHealthBar>())
			gameObject.AddComponent<GeneralHealthBar>();

		if(renenerationPerSecond > 0f)
		{
			if(!gameObject.GetComponent<LifeRegenerator>())
				gameObject.AddComponent<LifeRegenerator>();
		}
	}
	
	public void TakeDamage(DamageData damageData)
	{
		var value = damageData.damage_ammount;
		var armorPiercing = damageData.armorPiercing;

		if(armorPiercing == false)
			value = value - armor;

		currentHealth -= value;
		if(currentHealth < 0)
		{
			currentHealth = 0;
		}
	}

	public void Heal (float value)
	{
		currentHealth += value;
		if(currentHealth > startHealth)
		{
			currentHealth = startHealth;
		}
	}
	
	void Update()
	{
		if(currentHealth <=0)
			isDead = true;
	}
	
	public bool canTakeDamage 
	{
		get
		{
			if(currentHealth <= 0) return false;
			
			return true;
		}
	}

}
