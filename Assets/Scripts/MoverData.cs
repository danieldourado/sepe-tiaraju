using UnityEngine;
using System.Collections;

public class MoverData : MonoBehaviour 
{
	public int speed = 11;
	public bool isFlier = false;
	public bool isMoving;

	[HideInInspector]
	public Movement.Direction direction;
	[HideInInspector]
	public TravelData travel;
}
