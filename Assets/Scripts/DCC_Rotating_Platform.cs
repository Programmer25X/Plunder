using UnityEngine;

public class DCC_Rotating_Platform : MonoBehaviour
{
    [Header("Platform Rotation Properties")]
    [SerializeField] [Tooltip("Platform Rotation Speed")] [Range(0.25f, 100f)] private float rotationSpeedMultiplier = 1.0f;

    void Update()
    {
        transform.Rotate(0, 90.0f * Time.deltaTime * rotationSpeedMultiplier, 0); 
    }
}
