using UnityEngine;
using System.Collections;

public class HeroBehaviour : MonoBehaviour 
{
	public HeroData data;
	
	public void Awake () 
	{
		data = GetComponent<HeroData>();
	}
}
