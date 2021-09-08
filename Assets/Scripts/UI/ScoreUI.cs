using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI TextUI;
	[SerializeField] private Image FilledImage;
	[SerializeField] private Gradient FilledImageColor;

	private PlayerScore PlayerScore;

	private void Awake()
	{
		PlayerScore = FindObjectOfType<PlayerScore>();
	}

	private void Update()
	{
		TextUI.text = PlayerScore.Score.ToString();
		float FillAmount = PlayerScore.Score / 100f;
		FilledImage.fillAmount = Mathf.Clamp01(FillAmount);
		FilledImage.color = FilledImageColor.Evaluate(FillAmount);
	}
}
