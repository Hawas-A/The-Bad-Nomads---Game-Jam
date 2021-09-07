using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	[SerializeField] [Min(0)] private float Speed = 7;
	[SerializeField] [Min(0)] private float LifeTime = 10;

	public void Fire()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * Speed;
		Destroy(gameObject, LifeTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		Enemy enemy = other.GetComponentInParent<Enemy>();
		if (enemy)
		{
			enemy.OnHit();
		}
	}
}
