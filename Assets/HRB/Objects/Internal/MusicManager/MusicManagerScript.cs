using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

namespace HittingRockBottom
{
	[RequireComponent(typeof (AudioSource))]
	public class MusicManagerScript : NetworkBehaviour {
		[SerializeField] public string m_PathToStageMusic = "Sound/Music/Stages/";

		private AudioSource m_MusicPlayer;
		private AudioClip m_MusicClip;

		// Use this for initialization
		void Start () {
				m_MusicPlayer = GetComponent<AudioSource> ();
				m_MusicClip = (AudioClip)Resources.Load (m_PathToStageMusic + SceneManager.GetActiveScene ().name);

				if (m_MusicClip == null) {
					Debug.LogWarning ("WARNING!!! Could not load stage music " + m_PathToStageMusic + SceneManager.GetActiveScene ().name + "!");
				} else {
				
					m_MusicPlayer.spatialize = false;
					m_MusicPlayer.loop = true;
					m_MusicPlayer.clip = m_MusicClip;
					m_MusicPlayer.Play ();
			}
		}

		// Update is called once per frame
		void Update () {
			if ( isClient )
			{
				m_MusicPlayer.volume = PlayerPrefs.GetFloat ("volume");
			}
		}
	}
}