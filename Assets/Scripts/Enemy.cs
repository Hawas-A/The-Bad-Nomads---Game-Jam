using NaughtyAttributes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] [Tag] private string PlayerTag;
	[ShowNonSerializedField] private GameObject PlayerREF;


	private Rigidbody RB;

	private void Start()
	{
		PlayerREF = GameObject.FindGameObjectWithTag(PlayerTag);
		RB = GetComponent<Rigidbody>();
	}
}
