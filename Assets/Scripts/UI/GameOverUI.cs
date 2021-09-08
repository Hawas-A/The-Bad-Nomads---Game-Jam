using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
	[SerializeField] private GameObject[] DisabledObjects;
	[SerializeField] private Behaviour[] DisabledBehaviours;

	[SerializeField] private TextMeshProUGUI ScoreText;

	private void OnEnable()
	{
		System.Array.ForEach(DisabledObjects, O => O.SetActive(false));
		System.Array.ForEach(DisabledBehaviours, B => B.enabled = false);

		ScoreText.text = FindObjectOfType<PlayerScore>().Score.ToString();
	}
}
