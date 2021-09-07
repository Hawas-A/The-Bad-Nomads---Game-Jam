using UnityEngine;

public class StopWatchTimer : MonoBehaviour
{
	private RoundTimer RoundTimer;

	private void Awake()
	{
		RoundTimer = FindObjectOfType<RoundTimer>();
	}

	private void Update()
	{
		transform.localEulerAngles = Vector3.up * 360 * RoundTimer.RoundTimePercent;
	}
}
