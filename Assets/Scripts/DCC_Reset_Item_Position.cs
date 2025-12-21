using UnityEngine;

public class DCC_Reset_Item_Position : MonoBehaviour
{
    [SerializeField][Tooltip("The item the PC can pick-up and drop")] private GameObject item;

    private Vector3 initialItemPosition;
    private Vector3 initialItemRotation;

    void Start()
    {
        if (item != null)
        {
            initialItemPosition = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z);
            initialItemRotation = new Vector3(item.transform.rotation.x, item.transform.rotation.y, item.transform.rotation.z);
        }
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Spikes") || triggerHit.gameObject.CompareTag("PressurePlate"))
        {
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.SetPositionAndRotation(initialItemPosition, Quaternion.Euler(initialItemRotation));
            item.GetComponent<Rigidbody>().useGravity = true;


        }
    }
}
