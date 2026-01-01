using UnityEngine;

public class DCC_ArrowProjectile : MonoBehaviour
{
    private float _distance = 50.0f;
    private float _speed = 25.0f;
    private float _damage = 25.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, _distance / _speed);
        GetComponent<Rigidbody>().linearVelocity = _speed * transform.TransformDirection(Vector3.forward);
    }

    private void OnCollisionEnter(Collision colliderHit)
    {
        colliderHit.collider.gameObject.SendMessage("RecieveDamage", _damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject); 
    }
}
