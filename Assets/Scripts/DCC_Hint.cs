using UnityEngine;
using TMPro; 

public class DCC_Hint : MonoBehaviour
{
    [Header("Wave Properties")]
    [SerializeField] private float _frequency = 0.05f;
    [SerializeField] private float _magnitude = 3f;
    [SerializeField] private float _rotationSpeedMultiplier = 2f; 

    private Vector3 _initalPosition; 

    private void Start()
    {
        _initalPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, _initalPosition.y + _magnitude * Mathf.Sin(Time.time * _frequency), transform.position.z);
        transform.Rotate(0, 90.0f * Time.deltaTime * _rotationSpeedMultiplier, 0);
    }
}
