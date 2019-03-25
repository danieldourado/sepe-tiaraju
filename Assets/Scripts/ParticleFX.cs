using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleFX : MonoBehaviour 
{
	public List<AudioClip> sound;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play(Vector3 position)
	{
		transform.position = position;
		Main.instance.audioManager.PlayAudio(sound);
		Destroy (gameObject, this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length); 

	}
}
