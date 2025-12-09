using UnityEngine;

public class DCC_Reset_Item_Position : MonoBehaviour
{
    [SerializeField] [Tooltip("The item the PC can pick-up and drop")] private GameObject item;
    private Vector3 initialItemPosition;

    void Start()
    {
        if (item)
        {
            initialItemPosition = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Spikes"))
        {
            item.transform.position = initialItemPosition; 
        }
    }
}
