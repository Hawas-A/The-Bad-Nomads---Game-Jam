using NaughtyAttributes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] [Tag] private string PlayerTag;
	[ShowNonSerializedField] private GameObject PlayerREF;
	private PlayerScore PlayerScore;
	[SerializeField] private Transform VisualModel;
	[SerializeField] private AudioClip SpawnClip;

	[Header("Hit By Player Settings")]
	[SerializeField] [Min(0)] private int ScoreWorth = 5;
	[SerializeField] private AudioClip HitClip;

	[Header("Time Out Settings Settings")]
	[SerializeField] [Min(0)] private float LifeTime = 5;
	[SerializeField] [CurveRange(0, 0, 1, 1)] private AnimationCurve LifeTimeScale;
	[SerializeField] private AudioClip TimeOutClip;

	private float LifeTimeStart;
	private AudioSource AudioSource;

	private void Start()
	{
		PlayerREF = GameObject.FindGameObjectWithTag(PlayerTag);
		PlayerScore = PlayerREF.GetComponent<PlayerScore>();
		AudioSource = new GameObject($"{name}'s Audio Scource").AddComponent<AudioSource>();
		AudioSource.playOnAwake = false;
		AudioSource.transform.SetParent(transform.parent);
		AudioSource.transform.SetPositionAndRotation(transform.position, transform.rotation);
		AudioSource.clip = SpawnClip;
		AudioSource.Play();
	}

	private void OnEnable()
	{
		LifeTimeStart = Time.time;
	}

	private void Update()
	{
		if (Time.time >= LifeTimeStart + LifeTime)
		{
			gameObject.SetActive(false);
			AudioSource.clip = TimeOutClip;
			AudioSource.Play();
		}
		else
		{
			var LifeTimePercent = Mathf.Clamp01((Time.time - LifeTimeStart) / LifeTime);
			VisualModel.localScale = Vector3.one * LifeTimeScale.Evaluate(LifeTimePercent);
		}
	}


	public void OnHit()
	{
		Destroy(gameObject);
		PlayerScore.Score += ScoreWorth;

		AudioSource.clip = HitClip;
		AudioSource.Play();
		Destroy(AudioSource.gameObject, HitClip ? HitClip.length : 0.01f);
	}
}
