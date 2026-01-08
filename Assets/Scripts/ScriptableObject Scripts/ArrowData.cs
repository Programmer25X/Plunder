using UnityEngine;

[CreateAssetMenu(fileName = "ArrowObject", menuName = "Create new ArrowObject")]
public class ArrowData : ScriptableObject
{
    [Header("Arrow Properties")]
    [SerializeField] private float _distance = 50.0f;
    [SerializeField] private float _speed = 25.0f;
    [SerializeField] private float _damage = 25.0f;
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private GameObject _arrow;

    public float GetDamage() { return _damage; }
    public float GetSpeed() { return _speed; }
    public float GetDistance() { return _distance; }
    public float GetCooldown() { return _cooldown; }
    public GameObject GetArrow() { return _arrow; }

}
