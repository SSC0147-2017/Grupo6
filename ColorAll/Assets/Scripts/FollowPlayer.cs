using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		Vector3 playerPosition = FindObjectOfType<Player>().transform.position;
		transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
	}
}
