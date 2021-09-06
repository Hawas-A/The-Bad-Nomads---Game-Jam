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

	private void Awake()
	{
		PlayerREF = GameObject.FindGameObjectWithTag(PlayerTag);
		RB = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 PlayerDir = (PlayerREF.transform.position - RB.position).normalized;

		RB.MoveRotation(Quaternion.RotateTowards(RB.rotation,
										   Quaternion.LookRotation(PlayerDir),
										   AngularSpeed * Time.fixedDeltaTime));

		RB.MovePosition(Vector3.MoveTowards(RB.position,
									  PlayerREF.transform.position,
									  Speed * Time.fixedDeltaTime));
	}
}
