using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HittingRockBottom
{
	[RequireComponent(typeof(DiscordController))]
	public class LevelManager : MonoBehaviour {

		[SerializeField]
		public string m_NiceLevelName = "Level Name"; //Level name ingame, rich presence, etc.
		[SerializeField]
		public bool m_IsMenu = false;

		private bool m_DiscordInitialised;

		private DiscordController DiscordControl;
		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			if (m_DiscordInitialised)
			{
				if (!m_IsMenu) {
					DiscordControl.presence.partyMax = Network.maxConnections;
					DiscordControl.presence.partySize = Network.connections.Length;
				} else {
					DiscordControl.presence.partyMax = 1;
					DiscordControl.presence.partySize = 1;
				}
			}
		}

		public void OnDiscordInit()
		{
			DiscordControl = GetComponent<DiscordController> ();
			DiscordControl.presence.details = "Level: " + m_NiceLevelName;

			m_DiscordInitialised = true;
		}
	}
}