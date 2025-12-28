using UnityEngine;

public class DCC_SpikesAndWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggerHit)
    {
        if(triggerHit.gameObject.CompareTag("Player"))
        {
            triggerHit.SendMessage("RecieveDamage", 100.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
