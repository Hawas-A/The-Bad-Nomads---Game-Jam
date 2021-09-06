using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	[SerializeField] private GameObject[] EnemyPrefaps;
	[SerializeField] [Min(0)] private float SpawnRadius = 1;
	[SerializeField] [MinMaxSlider(0, 10)] private Vector2 SpawnRateRange = new Vector2(0.5f, 3f);

	[System.NonSerialized] public float SpawnRateMult = 1;

	private IEnumerator Start()
	{
		while (true)
		{
			var NewEnemy = Instantiate(EnemyPrefaps[Random.Range(0, EnemyPrefaps.Length)], transform);
			var RandomDirection = Random.onUnitSphere;
			RandomDirection.z = 0;
			RandomDirection.Normalize();

			NewEnemy.transform.localPosition = RandomDirection * SpawnRadius;

			yield return new WaitForSeconds(Random.Range(SpawnRateRange.x, SpawnRateRange.y));
		}
	}




	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, SpawnRadius);
	}
}
