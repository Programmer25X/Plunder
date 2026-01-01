using UnityEngine;

public class DCC_ArrowProjectile : MonoBehaviour
{
    private float distance = 50.0f;
    private float speed = 25.0f;
    private float damage = 25.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, distance / speed);
        GetComponent<Rigidbody>().linearVelocity = speed * transform.TransformDirection(Vector3.forward);
    }

    private void OnCollisionEnter(Collision colliderHit)
    {
        colliderHit.collider.gameObject.SendMessage("RecieveDamage", damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject); 
    }
}
