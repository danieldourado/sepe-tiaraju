using UnityEngine;
using System.Collections;

public class ObjectToPool : MonoBehaviour 
{
	public enum Type
	{
		Tower,
		Enemy,
		FX
	}

	public Type type;


	public void Setup (Type type)
	{
		this.type = type;

		FindObjectOfType<ObjectPool>().Add(this);
	}
	
	void OnDestroy()
	{
		var obj = FindObjectOfType<ObjectPool>();
		if(obj)
			obj.Remove(this);
	}
}
