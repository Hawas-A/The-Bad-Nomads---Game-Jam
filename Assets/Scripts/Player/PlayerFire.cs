using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
	[SerializeField] private InputActionReference PlayerFireInput;
	[SerializeField] private Projectile Bullet;
	[SerializeField] private Vector3 FirePointOffset = Vector3.up;
	[SerializeField] [Min(0.01f)] private float AttackSpeed = 1.5f;

	private void OnEnable()
	{
		PlayerFireInput.action.Enable();
		PlayerFireInput.action.performed += OnFire;
	}
	private void OnDisable()
	{
		PlayerFireInput.action.Disable();
		PlayerFireInput.action.performed -= OnFire;
	}

	private void OnFire(InputAction.CallbackContext CTX)
	{
		Instantiate(Bullet, transform.position + FirePointOffset, transform.rotation).Fire();
		StartCoroutine(AttackCoolDownCOR());
	}

	private IEnumerator AttackCoolDownCOR()
	{
		PlayerFireInput.action.performed -= OnFire;
		yield return new WaitForSeconds(1 / AttackSpeed);
		PlayerFireInput.action.performed += OnFire;
	}
}
