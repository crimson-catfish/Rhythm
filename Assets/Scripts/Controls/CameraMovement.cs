using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] private float zoomBack;
    [SerializeField] private ControlSettings controlSettings;
	[SerializeField] private InputCenter inputCenter;
	[SerializeField] private float rotationCap;
	[SerializeField] private float MovementSpeed;
	[SerializeField] private float RotationSpeed;

	private Vector2 aim;
	private Vector3 originalLookDirection;
	private Quaternion originalRotation;
	private Transform playerTransform;
	private Vector3 shiftBack;



    private void OnEnable()
    {
        inputCenter.OnAim += HandleAim;
    }

	private void Start()
	{
		playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
		originalLookDirection = transform.forward;
		originalRotation = transform.rotation;
		shiftBack = -originalLookDirection * zoomBack;
	}
	
	private void FixedUpdate()
	{
		Move();
		Rotate();
	}
	
    private void OnDisable()
    {
        inputCenter.OnAim -= HandleAim;
    }


	private void HandleAim(Vector2 aimArg)
	{
		aim = aimArg;

		// Remap mousePosition vector to [-1, 1] range
		if (controlSettings.isGamepad == false)
		{
			aim.x = (aim.x * 2 / Screen.currentResolution.width) - 1.0f;
			aim.y = (aim.y * 2 / Screen.currentResolution.height) - 1.0f;
		}
	}

	private void Move()
	{
		Vector3 targetPosition = new Vector3(playerTransform.transform.position.x, 0.0f, playerTransform.transform.position.z) + shiftBack;

		transform.position = Vector3.Lerp(transform.position, targetPosition, MovementSpeed);
	}

	private void Rotate()
	{
		Vector3 targetLook = originalLookDirection + (originalRotation * new Vector3(aim.x, aim.y, 0.0f) * rotationCap);
		Quaternion targetRotation = Quaternion.LookRotation(targetLook);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed);
	}
}