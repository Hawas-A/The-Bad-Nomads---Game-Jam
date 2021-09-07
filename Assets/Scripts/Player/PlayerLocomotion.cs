using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerLocomotion : MonoBehaviour
{
	[SerializeField] private InputActionReference PlayerMovment;
	[SerializeField] [Min(0)] private float MovmentSpeed = 4;

	private Rigidbody RB;

	private void Awake()
	{
		RB = GetComponent<Rigidbody>();
	}

	private void OnEnable()
	{
		PlayerMovment.action.Enable();
	}

	private void OnDisable()
	{
		PlayerMovment.action.Disable();
	}

	private void FixedUpdate()
	{
		var inputValue = PlayerMovment.action.ReadValue<Vector2>();
		if (inputValue != Vector2.zero)
		{
			RB.MovePosition(RB.position + (MovmentSpeed * Time.fixedDeltaTime * new Vector3(inputValue.x, 0, inputValue.y)));
		}
	}
}
