using UnityEngine;

public class DCC_PC_Movement : MonoBehaviour
{
    // Player Movement Variables
    [Header("Player Movement Properties")]
    [SerializeField][Tooltip("PC Jump Force Exerted")] private float _jumpForce = 8.0f;
    [SerializeField][Tooltip("PC Rotation Speed")] private float _rotationSpeed = 180f;
    private float _movementSpeed;
    private const float _GRAVITY = 9.81f;
    private Vector3 _movementDirection = Vector3.zero;


    // Camera Variables
    private Camera _mainCamera;
    private float _cameraXAxis = 0;


    // PC Character Controller
    private CharacterController characterController;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
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
        float walkingSpeed = 10.0f;
        float sprintSpeed = walkingSpeed * 2;

        _movementSpeed = Input.GetKey(KeyCode.LeftShift) ? walkingSpeed : sprintSpeed;

        transform.Rotate(0, _rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), 0);
        _cameraXAxis -= Input.GetAxis("Mouse Y");
        _cameraXAxis = Mathf.Clamp(_cameraXAxis, -80.0f, 20.0f);
        _mainCamera.transform.localRotation = Quaternion.Euler(new Vector3(_cameraXAxis, _mainCamera.transform.localRotation.y, _mainCamera.transform.localRotation.z));

        if (characterController.isGrounded)
        {
            _movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _movementDirection.Normalize();
            _movementDirection = _movementSpeed * transform.TransformDirection(_movementDirection);

            if (Input.GetButton("Jump"))
            {
                _movementDirection.y = _jumpForce;
            }
        }

        _movementDirection.y -= _GRAVITY * Time.deltaTime;

        characterController.Move(_movementDirection * Time.deltaTime);
    }
}
