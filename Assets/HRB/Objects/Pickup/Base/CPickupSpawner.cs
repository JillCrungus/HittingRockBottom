using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace HittingRockBottom
{
	public class CPickupSpawner : NetworkBehaviour {


		public CPickup m_CurrentPickup;
		public float m_PickupHeightOffset = 32.0f;
		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void PickupGrabbed()
		{
		}
	}

}