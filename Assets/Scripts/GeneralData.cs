using UnityEngine;
using System.Collections;

public class GeneralData : MonoBehaviour 
{
	public string description = "Descriçao";
	public string name = "Nome";
	public int reloadTime = 1500;
	public int reward = 10;
	public float startHealth = 100f;
	public float currentHealth = 0f;
	public int speed = 11;
	public int damage = 1;
	public bool isFlier = false;
	public float timeToResetAfterDead = 5f;
	public bool isDead;
	[HideInInspector]
	public Movement.Direction direction;
	public TravelData travelData;
}
