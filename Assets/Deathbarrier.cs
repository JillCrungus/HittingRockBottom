using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeathBarrier : MonoBehaviour {
	private static DeathBarrier _Instance;

	public static DeathBarrier Instance { get { return _Instance; } }

	void Awake()
	{
		_Instance= this;
	}
}
	