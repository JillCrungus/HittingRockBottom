using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


namespace HittingRockBottom
{
	[Serializable]
	public class CPickup : NetworkBehaviour {

		//Visual
		[SerializeField]
		private SkinnedMeshRenderer m_ViewModel;
		[SerializeField]
		private MeshRenderer m_WorldModel;

		//Ammo
		[SerializeField]
		public bool m_UseAmmo; //Does this weapon use ammo?
		private int m_AmmoCount; //How much ammo do we have right now?
		[SerializeField]
		public int m_DefaultAmmo; //Default Ammo Count

		[SerializeField]
		public bool m_UseProjectiles;
		public CProjectile m_ProjectileType;

		//Owner
		private UnityStandardAssets.Characters.FirstPerson.CHRBPlayer m_Owner;



		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void SetAmmo(int AmmoCount)
		{
			if (m_UseAmmo) {
				m_AmmoCount = AmmoCount;
			} else {
				Debug.LogWarning ("SetAmmo called on CPickup that doesn't use ammo!");
			}
		}

		public int GetAmmo()
		{
			if (m_UseAmmo) {
				return m_AmmoCount;
			} else {
				Debug.LogWarning ("GetAmmo called on CPickup that doesn't use ammo!");
				return 0;
			}
		}
	}
}