using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCamScript : MonoBehaviour {

	private GameObject TargetPosition;
	[SerializeField] public GameObject[] PossiblePositions;
	[SerializeField] public int CurrentPosition;
	private float PosSpeed;
	private Vector3 tempPos;
	private Quaternion tempRot;
	// Use this for initialization
	void Start () {

		PosSpeed = 0.05f;

		CurrentPosition = 0;
	}
	
	// Update is called once per frame
	void Update () {
		TargetPosition = PossiblePositions [CurrentPosition];

		if (TargetPosition != null) {
			tempPos = transform.position;
			tempPos.x += (TargetPosition.transform.position.x - transform.position.x) * PosSpeed;
			tempPos.y += (TargetPosition.transform.position.y - transform.position.y) * PosSpeed;
			tempPos.z += (TargetPosition.transform.position.z - transform.position.z) * PosSpeed;
			transform.position = tempPos;

			tempRot = transform.rotation;
			tempRot.x += Mathf.Sin (TargetPosition.transform.rotation.x - transform.rotation.x) * PosSpeed;
			tempRot.y += Mathf.Sin (TargetPosition.transform.rotation.y - transform.rotation.y) * PosSpeed;
			tempRot.z += Mathf.Sin (TargetPosition.transform.rotation.z - transform.rotation.z) * PosSpeed;
			transform.rotation = tempRot;
		}
		if (SceneManager.GetActiveScene ().name != "Menu_Network") {
			DestroyObject (this);
		}


	}
}
