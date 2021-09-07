using NaughtyAttributes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] [Tag] private string PlayerTag;
	[ShowNonSerializedField] private GameObject PlayerREF;
	private PlayerScore PlayerScore;

	[Space]
	[SerializeField] [Min(0)] private int ScoreWorth = 5;

	private Rigidbody RB;

	private void Start()
	{
		PlayerREF = GameObject.FindGameObjectWithTag(PlayerTag);
		PlayerScore = PlayerREF.GetComponent<PlayerScore>();
		RB = GetComponent<Rigidbody>();
	}

	public void OnHit()
	{
		gameObject.SetActive(false);
		PlayerScore.Score += ScoreWorth;
	}
}
