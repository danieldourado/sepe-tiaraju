using UnityEngine;
using System.Collections;

public class DamageData : MonoBehaviour 
{
	[Range(1,200)]
	public int damage_ammount = 10;
	[Range(100,1000)]
	public float range = 200;
	[Range(0,100)]
	public float damage_area = 0;
	[Header("Reload in Seconds")]
	[Range(0,10)]
	public float reloadTime = 2;

	public float delayOfAttack = 0.4f;

	public bool armorPiercing = false;


	public bool shootsFlier = false;
	
	[Range(0.1f,3f)]
	public float maxTimeProjectileStaysInAir = 0.5f;

	public WeaponType weaponType = WeaponType.Warrior;

	public GameObject projectile;

	public enum WeaponType
	{
		Arrow,
		Bomb,
		Warrior,
		MagicSpell
	}
}
