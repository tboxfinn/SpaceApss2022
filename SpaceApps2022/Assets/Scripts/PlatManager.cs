using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatManager : MonoBehaviour
{
	public static PlatManager Instance = null;

	[SerializeField]
	GameObject platformPrefab;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

	}
	// Use this for initialization
	void Start()
	{
		
		Instantiate(platformPrefab, new Vector2(0f, -2.5f), platformPrefab.transform.rotation);
		
	}

	IEnumerator SpawnPlatform(Vector2 spawnPosition)
	{
		yield return new WaitForSeconds(3f);
		Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
	}
}
