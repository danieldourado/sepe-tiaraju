using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour 
{

	public List<GameObject> enemies;

	void Start () 
	{
		Main.instance.DisableLoadingScreen();
		enemies = new List<GameObject>();
	}

	public void Add(ObjectToPool objectToPool)
	{
		if(objectToPool.type == ObjectToPool.Type.Enemy)
			enemies.Add(objectToPool.gameObject);
	}

	public void Remove (ObjectToPool objectToPool)
	{
		if(objectToPool.type == ObjectToPool.Type.Enemy)
			enemies.Remove(objectToPool.gameObject);
	}

}
