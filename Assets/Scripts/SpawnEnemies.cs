using NaughtyAttributes;
using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	[SerializeField] [Min(1)] private int MaxSpawnCount = 3;
	[SerializeField] [MinMaxSlider(0, 10)] private Vector2 SpawnRateRange = new Vector2(0.5f, 3f);

	private Enemy[] Enemies;
	[System.NonSerialized] public float SpawnRateMult = 1;

	private void Awake()
	{
		Enemies = FindObjectsOfType<Enemy>(true);
		System.Array.ForEach(Enemies, E => E.gameObject.SetActive(false));
	}

	private IEnumerator Start()
	{
		while (true)
		{
			var RandomDirection = Random.onUnitSphere;
			RandomDirection.z = 0;
			RandomDirection.Normalize();

			var SpawnCount = Random.Range(1, MaxSpawnCount);
			for (int i = 0; i < SpawnCount; i++)
			{
				var DisabledEnemies = Enemies.Where(E => !E.gameObject.activeSelf);
				DisabledEnemies.ElementAt(Random.Range(0, DisabledEnemies.Count())).gameObject.SetActive(true);
			}
			yield return new WaitForSeconds(SpawnRateMult * Random.Range(SpawnRateRange.x, SpawnRateRange.y));
		}
	}
}
