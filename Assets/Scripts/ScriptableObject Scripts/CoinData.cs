using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "Create new Coin")]
public class CoinData : ScriptableObject
{
    [Header("Coin Properties")]
    [SerializeField] private float _frequency = 0.05f;
    [SerializeField] private float _magnitude = 3f;
    [SerializeField] private float _rotationSpeedMultiplier = 2f;
    [SerializeField] private AudioClip _clip;

    public AudioClip GetAudioClip() { return _clip; }
    public float GetFrequency() { return _frequency; }
    public float GetMagnitude() { return _magnitude; }
    public float GetRotationSpeedMultiplier() { return _rotationSpeedMultiplier; }

}
