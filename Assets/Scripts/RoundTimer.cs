using NaughtyAttributes;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoundTimer : MonoBehaviour
{
	[field: SerializeField] [field: Min(0)] public float RoundDuration { get; private set; } = 30;

	public float RoundTime => Time.time - RoundStartTime;
	[ShowNativeProperty] public float RoundTimePercent => Mathf.Clamp01(RoundTime / RoundDuration);

	private float RoundStartTime;

	[SerializeField] private InputActionReference[] Inputs;

	private void Awake()
	{
		RoundStartTime = Time.time;
	}

	private void Update()
	{
		if (RoundTimePercent == 1)
		{
			enabled = false;
			FindObjectOfType<GameOverUI>(true).gameObject.SetActive(true);
		}
	}

	private void OnDisable()
	{
		System.Array.ForEach(Inputs, IAR => IAR.action.Disable());
		System.Array.ForEach(FindObjectsOfType<Enemy>(), E => Destroy(E.gameObject));
		System.Array.ForEach(FindObjectsOfType<AudioSource>().Where(AS => !AS.playOnAwake).ToArray(),
			AS => AS.Stop());
	}
}
