using UnityEngine;

public class DCC_Reset_Item_Position : MonoBehaviour
{
    [Header("Interactable Item")]
    [SerializeField][Tooltip("The item the PC can pick-up and drop")] private GameObject _item;

    private Vector3 _initialItemPosition;
    private Vector3 _initialItemRotation;

    void Start()
    {
        if (_item)
        {
            _initialItemPosition = new Vector3(_item.transform.position.x, _item.transform.position.y, _item.transform.position.z);
            _initialItemRotation = new Vector3(_item.transform.rotation.x, _item.transform.rotation.y, _item.transform.rotation.z);
        }
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Spikes") || triggerHit.gameObject.CompareTag("PressurePlate") || triggerHit.gameObject.CompareTag("Water"))
        {
            _item.transform.parent = null;
            _item.GetComponent<Rigidbody>().isKinematic = true;
            _item.transform.SetPositionAndRotation(_initialItemPosition, Quaternion.Euler(_initialItemRotation));
            _item.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
