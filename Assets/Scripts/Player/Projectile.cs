using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Projectile : MonoBehaviour
{
	[SerializeField] [Tag()] private string PlayerTag;
	[SerializeField] [Min(0)] private float Speed = 7;
	[SerializeField] [Min(0)] private float LifeTime = 10;
	[SerializeField] private AudioClip FireClip;
	[SerializeField] private AudioClip HitEnemyClip;
	[SerializeField] private AudioClip HitEnvironmentClip;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void Fire()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * Speed;
		audioSource.clip = FireClip;
		audioSource.Play();
		Destroy(gameObject, LifeTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		Enemy enemy = other.GetComponentInParent<Enemy>();
		if (enemy)
		{
			enemy.OnHit();
			audioSource.clip = HitEnemyClip;
			audioSource.Play();
		}
		else if (other.attachedRigidbody && other.attachedRigidbody.gameObject.CompareTag(PlayerTag))
		{

		}
		else
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			audioSource.clip = HitEnvironmentClip;
			audioSource.Play();
			Destroy(gameObject, HitEnvironmentClip ? HitEnvironmentClip.length : 0.01f);
		}
	}
}
