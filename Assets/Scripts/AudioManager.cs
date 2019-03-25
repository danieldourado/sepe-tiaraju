using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour 
{

	private AudioSource m_audioSource;

	void Awake () 
	{
		m_audioSource = GetComponent<AudioSource>();
		GameStateManager.OnGameStateChangeToLoading += StopAudio;
	}
	
	public void PlayAudio(List<AudioClip> audioClip)
	{
		if(audioClip == null) return;

		var trackToPlay = Random.Range(0, audioClip.Count);

		Play(audioClip[trackToPlay]);

	}

	public void PlayAudio(AudioClip audioClip)
	{
		if(audioClip == null) return;
		
		Play(audioClip);
	}

	void Play(AudioClip audioClip)
	{
		m_audioSource.PlayOneShot(audioClip);
	}

	void StopAudio()
	{
		m_audioSource.Stop();
	}
}
