using UnityEngine;
using System.Collections;

public class HealthData : MonoBehaviour 
{
	public float startHealth = 100f;
	public float currentHealth = 0f;
	public float timeToResetAfterDead = 5f;
	public bool isDead;
}
