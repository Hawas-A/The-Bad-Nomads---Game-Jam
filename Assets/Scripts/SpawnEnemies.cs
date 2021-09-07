using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	[SerializeField] [MinMaxSlider(0, 10)] private Vector2 SpawnRateRange = new Vector2(0.5f, 3f);

	private Enemy[] EnemyPrefaps;
	[System.NonSerialized] public float SpawnRateMult = 1;

	private void Awake()
	{
		EnemyPrefaps = FindObjectsOfType<Enemy>(true);
		System.Array.ForEach(EnemyPrefaps, E => E.gameObject.SetActive(false));
	}

	private IEnumerator Start()
	{
		while (true)
		{
			var RandomDirection = Random.onUnitSphere;
			RandomDirection.z = 0;
			RandomDirection.Normalize();

			//var Disabled

			yield return new WaitForSeconds(SpawnRateMult * Random.Range(SpawnRateRange.x, SpawnRateRange.y));
		}
	}
}
