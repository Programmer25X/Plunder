using UnityEngine;

public class DCC_Checkpoints : MonoBehaviour
{

    private void OnTriggerEnter(Collider triggerHit)
    {
        if(triggerHit.gameObject.CompareTag("Player"))
        {
            Debug.Log("Activated Checkpoint");
            triggerHit.SendMessage("SetCheckpointLocation", transform.position, SendMessageOptions.RequireReceiver);
        }
    }

}
