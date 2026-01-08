using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DCC_ArrowBehaviour : MonoBehaviour
{
    public ArrowData arrowData;

    void Start()
    {
        Destroy(gameObject, arrowData.GetDistance() / arrowData.GetSpeed());
        GetComponent<Rigidbody>().linearVelocity = arrowData.GetSpeed() * transform.TransformDirection(Vector3.forward);
    }

    private void OnCollisionEnter(Collision colliderHit)
    {
        colliderHit.collider.gameObject.SendMessage("RecieveDamage", arrowData.GetDamage(), SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
