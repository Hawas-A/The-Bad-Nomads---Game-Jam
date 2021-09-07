using UnityEngine;
using UnityEngine.InputSystem;

public class EnvironmentRotation : MonoBehaviour
{
	[SerializeField] private InputActionReference EnvRotation;
	[SerializeField] [Min(0)] private float RotaionSpeed = 60;

	private void OnEnable()
	{
		EnvRotation.action.Enable();
	}

	private void OnDisable()
	{
		EnvRotation.action.Disable();
	}

	private void Update()
	{
		var inputValue = EnvRotation.action.ReadValue<float>();
		if (inputValue != 0)
		{
			transform.Rotate(Vector3.up, inputValue * RotaionSpeed * Time.deltaTime);
		}
	}
}
