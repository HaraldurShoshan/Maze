using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSounds : MonoBehaviour {

	public AudioSource SoundSource;
	public AudioClip Sound;

	float incVolume = 0.0f;
	float volRate = 0.08f;

	private bool hasPlayedAudio;
	private bool collect = true;

	private void Update()
	{
		if (hasPlayedAudio) 
		{
			SoundSource.volume = incVolume;
			incVolume += volRate;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.CompareTag ("Player") && hasPlayedAudio == false) 
		{
			SoundSource.volume = 0.01f;
			SoundSource.clip = Sound;
			SoundSource.Play ();
			hasPlayedAudio = true;

		} 
		else if (other.gameObject.CompareTag ("Player") && hasPlayedAudio == true) 
		{
			SoundSource.volume = 0.0f;
			SoundSource.Stop ();
			hasPlayedAudio = false;
		}
			
	}
		
}
