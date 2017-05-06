using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSounds : MonoBehaviour {

	public AudioSource SoundSource;
	public AudioClip Sound;

	float incVolume = 0.03f;
	//float volRate = 0.0008f;

	private bool hasPlayedAudio = false;
	private bool collect = true;

	private void Update()
	{
//		Debug.Log (hasPlayedAudio);
//		if (hasPlayedAudio) 
//		{
//			SoundSource.volume = incVolume;
//			incVolume += volRate;
//		}
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.CompareTag ("Player") && !hasPlayedAudio) 
		{
			SoundSource.volume = incVolume;
			SoundSource.clip = Sound;
			SoundSource.Play ();
			hasPlayedAudio = true;

		} 
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player") && hasPlayedAudio) 
		{
			SoundSource.volume = 0.0f;
			SoundSource.Stop ();
			hasPlayedAudio = false;
		}
	}
		
}
