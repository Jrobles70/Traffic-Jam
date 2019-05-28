﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public GameObject [] cars;
	public float [] spawn_pos;
	public float spawn_wait;
	public float z_pos;
	public float x_min, x_max;
	private bool gameover = false;

	private IEnumerator spawn () {

		while (!gameover) {

			GameObject car;
			int index = (int) Random.Range (0.0f, 4.0f);
			car = cars [Random.Range (0, cars.Length)];
			Vector3 position = new Vector3 (spawn_pos[index], 0.0f, z_pos);
			Instantiate (car, position, transform.rotation);
			yield return new WaitForSeconds (spawn_wait);
			spawn_wait = spawn_wait - 0.001f;
		}

	}

	void Start () {
		// Debug.Log (gameObject.tag + " started");
		StartCoroutine( spawn ());
	}

	public void GameOver () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Level");
		if (objs.Length > 0) {
			foreach(GameObject go in objs)  {
				MoveRoad level = go.GetComponent<MoveRoad>();
				level.SetVelocity(new Vector3(0.0f, 0.0f, 0.0f));
			}
		}
		else
			Debug.Log ("cannot find 'MoveRoad' script");
		
		gameover = true;
		Debug.Log ("Game Over!");
	}

}


