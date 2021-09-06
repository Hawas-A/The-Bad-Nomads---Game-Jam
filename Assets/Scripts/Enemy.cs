using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
	[SerializeField] [Tag] private string PlayerTag;
	[SerializeField] [Min(0)] private float Speed = 1;
	[SerializeField] [Min(0)] private float AngularSpeed = 10;

	[ShowNonSerializedField] private GameObject PlayerREF;
	private Rigidbody RB;

	private void Start()
	{
		PlayerREF = GameObject.FindGameObjectWithTag(PlayerTag);
		RB = GetComponent<Rigidbody>();
		transform.forward = (PlayerREF.transform.position - transform.position).normalized;
	}

	private void FixedUpdate()
	{
		Vector3 PlayerDir = PlayerREF.transform.position - RB.position;

		if (PlayerDir != Vector3.zero)
		{
			RB.MoveRotation(Quaternion.RotateTowards(RB.rotation,
											   Quaternion.LookRotation(PlayerDir.normalized),
											   AngularSpeed * Time.fixedDeltaTime));

			RB.MovePosition(Vector3.MoveTowards(RB.position,
										  PlayerREF.transform.position,
										  Speed * Time.fixedDeltaTime));
		}
	}
}
