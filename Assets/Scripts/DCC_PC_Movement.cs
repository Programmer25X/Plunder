using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class DCC_PC_Movement : MonoBehaviour
{
    // Player Movement Variables
    [Header("Player Movement Properties")]
    [SerializeField][Tooltip("PC Jump Force Exerted")] private float _jumpForce = 8.0f;
    [SerializeField][Tooltip("PC Rotation Speed")] private float _rotationSpeed = 180f;
    [SerializeField][Tooltip("PC Walking Speed")] private float _walkingSpeed = 10.0f;
    [SerializeField][Tooltip("PC Sprinting Speed")] private float _sprintSpeed = 20.0f;

    private float _movementSpeed;
    private const float _GRAVITY = 20.0f;
    private Vector3 _movementDirection = Vector3.zero;

    // Camera Variables
    private CinemachineCamera _cinemachineCamera;
    private float _cameraXAxis = 0;


    // PC Character Controller
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _cinemachineCamera = FindAnyObjectByType<CinemachineCamera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (characterController && Time.timeScale == 1)
        {
            MovePlayerCharacter();
        }
    }

    /// <summary>
    /// Player Character Movement
    /// </summary>
    void MovePlayerCharacter()
    {
        if (Input.GetAxis("Vertical") > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            _movementSpeed = _sprintSpeed;
        }
        else
        {
            _movementSpeed = _walkingSpeed;
        }

        transform.Rotate(0, _rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), 0);
        _cameraXAxis -= Input.GetAxis("Mouse Y");
        _cameraXAxis = Mathf.Clamp(_cameraXAxis, -80.0f, 20.0f);
        _cinemachineCamera.transform.localRotation = Quaternion.Euler(new Vector3(_cameraXAxis, _cinemachineCamera.transform.localRotation.y, _cinemachineCamera.transform.localRotation.z));

        if (characterController.isGrounded)
        {
            _movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            _movementDirection = _movementSpeed * transform.TransformDirection(_movementDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movementDirection.y = Mathf.Sqrt(_jumpForce * 2f * _GRAVITY);
            }
        }

        _movementDirection.y -= _GRAVITY * 2 * Time.deltaTime;

        if (_movementDirection.magnitude >= 0.1f)
        {
            characterController.Move(_movementDirection * Time.deltaTime);
        }
    }
}
