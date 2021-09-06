using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	[SerializeField] private Enemy[] EnemyPrefaps;
	[SerializeField] [Min(0)] private float SpawnRadius = 1;
	[SerializeField] [MinMaxSlider(0, 10)] private Vector2 SpawnRateRange = new Vector2(0.5f, 3f);

	[System.NonSerialized] public float SpawnRateMult = 1;

	private IEnumerator Start()
	{
		while (true)
		{
			var RandomDirection = Random.onUnitSphere;
			RandomDirection.z = 0;
			RandomDirection.Normalize();

			Instantiate(EnemyPrefaps[Random.Range(0, EnemyPrefaps.Length)], transform.TransformPoint(RandomDirection * SpawnRadius),
				Quaternion.identity, transform);

			yield return new WaitForSeconds(Random.Range(SpawnRateRange.x, SpawnRateRange.y));
		}
	}




	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, SpawnRadius);
	}
}
