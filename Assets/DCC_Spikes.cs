using UnityEngine;

public class DCC_Spikes : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggerHit)
    {
        if(triggerHit.gameObject.CompareTag("Player"))
        {
            triggerHit.SendMessage("RecieveDamage", 100.0f);
        }
    }
}
