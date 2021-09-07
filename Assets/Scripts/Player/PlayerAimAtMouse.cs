using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimAtMouse : MonoBehaviour
{
	[ShowNativeProperty] public Vector3 MousePointerWorldPosition { get; private set; }

	private Camera MainCam;

	private void Awake()
	{
		MainCam = Camera.main;
	}

	private void Update()
	{
		var ray = MainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
		var plane = new Plane(Vector3.up, transform.position);
		if (plane.Raycast(ray, out var distance))
		{
			MousePointerWorldPosition = ray.GetPoint(distance);

			var MouseDirection = MousePointerWorldPosition - transform.position;
			if (MouseDirection != Vector3.zero)
			{
				transform.forward = MouseDirection;
			}
		}
	}
}
