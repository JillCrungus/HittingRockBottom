using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


namespace HittingRockBottom
{

	[RequireComponent(typeof (MeshFilter))]

	[Serializable]
	public class CPickup : NetworkBehaviour {

		//Visual
		[SerializeField]
		private SkinnedMeshRenderer m_ViewModel;
		private MeshFilter m_MeshFilter_View;
		[SerializeField]
		private MeshRenderer m_WorldModel;
		private MeshFilter m_MeshFilter_World;
		[SerializeField]
		private string m_NiceName = "Weapon Base";

		//Ammo
		[SerializeField]
		public bool m_UseAmmo; //Does this weapon use ammo?
		private int m_AmmoCount; //How much ammo do we have right now?
		[SerializeField]
		public int m_DefaultAmmo; //Default Ammo Count

		[SerializeField]
		public bool m_UseProjectiles;
		[SerializeField]
		public CProjectile m_ProjectileType;

		//Owner
		private UnityStandardAssets.Characters.FirstPerson.CHRBPlayer m_Owner;
		private CPickupSpawner m_OwningSpawner;

		public enum EWeaponState : int
		{
			WEAPON_STATE_SPAWNED = 0,
			WEAPON_STATE_HELD,
			WEAPON_STATE_INVALID = 100,
		}



		private EWeaponState m_CurrentWeaponState;

		// Use this for initialization
		protected virtual void Start () {
			m_WorldModel.enabled = false;
			m_ViewModel.enabled = false;
			m_MeshFilter_World = GetComponent<MeshFilter> ()0;
			Math-m_WorldModel.
		}
		
		// Update is called once per frame
		protected virtual void Update () {
			switch (m_CurrentWeaponState) {
			case EWeaponState.WEAPON_STATE_SPAWNED:
				Update_InSpawner ();
				break;
			case EWeaponState.WEAPON_STATE_HELD:
				Update_Held ();
				break;
			default:
				Debug.LogError ("Weapon " + m_NiceName + " has invalid state!");
				break;
			}
		}

		void Update_InSpawner()
		{
			m_WorldModel. = true;
		}

		void Update_Held()
		{
			m_WorldModel.enabled = false;
			m_ViewModel.enabled = true;

			if ( isLocalPlayer && Input.GetButtonDown("Attack 1") )
			{
				Fire();
			}
		}

		protected virtual void Fire()
		{
			Debug.Log ("Weapon fired!");
		}


		void AddToPlayer(UnityStandardAssets.Characters.FirstPerson.CHRBPlayer player)
		{
			SetState (EWeaponState.WEAPON_STATE_HELD);
			m_Owner = player;
			m_OwningSpawner.PickupGrabbed ();
		}

		//Set the current state of the weapon
		public void SetState(EWeaponState NewState)
		{
			m_CurrentWeaponState = NewState;
		}

		//Get the current state of the weapn
		public EWeaponState GetState()
		{
			return m_CurrentWeaponState;
		}
			
		//Set the current ammo count of the weapon
		public void SetAmmo(int AmmoCount)
		{
			if (m_UseAmmo) {
				m_AmmoCount = AmmoCount;
			} else {
				Debug.LogWarning ("SetAmmo called on CPickup that doesn't use ammo!");
			}
		}

		//Get the current ammo count of the weapon
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