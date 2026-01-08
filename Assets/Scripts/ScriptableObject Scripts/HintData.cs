using UnityEngine;

[CreateAssetMenu(fileName = "HintData", menuName = "Create a Hint")]
public class HintData : ScriptableObject
{
    [Header("Hint Properties")]
    [SerializeField] private float _frequency = 0.05f;
    [SerializeField] private float _magnitude = 3f;
    [SerializeField] private float _rotationSpeedMultiplier = 2f;

    public float GetFrequency() { return _frequency; }
    public float GetMagnitude() { return _magnitude; }
    public float GetRotationSpeedMultiplier() { return _rotationSpeedMultiplier; }

}
