using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	[SerializeField] [Min(1)] private int MaxSpawnCount = 3;
	[SerializeField] [MinMaxSlider(0, 10)] private Vector2 SpawnRateRange = new Vector2(0.5f, 3f);

	[SerializeField] private Enemy[] Enemies;
	[SerializeField] [Min(0)] private float SpawnRadius = 20;

	[System.NonSerialized] public float SpawnRateMult = 1;
	private IEnumerator COR;

	private void Awake()
	{
		COR = Spawn();
	}

	private void OnEnable()
	{
		StartCoroutine(COR);
	}

	private void OnDisable()
	{
		StopCoroutine(COR);
	}

	private IEnumerator Spawn()
	{
		while (true)
		{
			var SpawnCount = Random.Range(1, MaxSpawnCount);
			for (int i = 0; i < SpawnCount; i++)
			{
				Instantiate(Enemies[Random.Range(0, Enemies.Length)],
					Vector3.ProjectOnPlane(Random.insideUnitSphere * SpawnRadius, Vector3.up),
					Quaternion.Euler(0, Random.Range(0, 360), 0),
					transform);
			}
			yield return new WaitForSeconds(SpawnRateMult * Random.Range(SpawnRateRange.x, SpawnRateRange.y));
		}
	}


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, SpawnRadius);
	}
}
