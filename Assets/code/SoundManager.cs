using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	
	public static SoundManager Instance = null;

	
	private void Awake()
	{
		
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			DontDestroyOnLoad(gameObject);
			Destroy(gameObject);
			Instance = null;
		}

		
	}


	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}
}
