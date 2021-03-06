﻿using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour 
{
	public ParticleSystem cubeDeathParticle;
	GameManager gameManagerScript;
	public AudioClip destroySound;
	public AudioClip loseSound;	

	void Start()
	{
		gameManagerScript = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		GameManager.isAlive = true;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Bound")
		{
			KillCube();
		}
	}

	public void KillCube()
	{
		Instantiate(cubeDeathParticle, this.gameObject.transform.position, Quaternion.Euler(-90,0,0));
		GameManager.isAlive = false;
		gameManagerScript.ReloadGame ();
		Destroy(this.gameObject);
		AudioSource.PlayClipAtPoint (loseSound, new Vector3 (0, 0, 0));
		AudioSource.PlayClipAtPoint (destroySound, new Vector3 (0, 0, 0));
	}


}
