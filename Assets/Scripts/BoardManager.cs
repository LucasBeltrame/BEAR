using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;

		public Count(int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public int nbForestTab = 8;
	public Count resCount = new Count(3, 7);
	public GameObject[] logs;
	public GameObject cabin;
	public GameObject sign;

	private Transform boardHolder;
	private List<Vector2> tabPositions = new List<Vector2>();

	void InitialiseList ()
	{
		tabPositions.Clear ();

		// Différents niveaux de la forêt, pas position x,y dans le niveau en soit
		for (int i = 0; i < nbForestTab; i++)
			tabPositions.Add (new Vector2 (i, 0f));
	}

	Vector2 RandomPosition ()
	{
		int randomIndex = Random.Range (0, tabPositions.Count);
		Vector2 randomPosition = tabPositions [randomIndex];
		tabPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom (GameObject[] objectArray, int minimum, int maximum)
	{
		int objectCount = Random.Range (minimum, maximum + 1);
		for (int i = 0; i < objectCount; i++)
		{
			Vector2 randomPosition = RandomPosition ();
			GameObject newObject = objectArray [Random.Range (0, objectArray.Length)];
			Instantiate (newObject, randomPosition, Quaternion.identity);
		}
	}

	public void SetupScene ()
	{
		InitialiseList ();
		LayoutObjectAtRandom (logs, resCount.minimum, resCount.maximum);
	}
}
