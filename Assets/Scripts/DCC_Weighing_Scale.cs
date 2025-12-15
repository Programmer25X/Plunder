using UnityEngine;

public class DCC_Weighing_Scale : MonoBehaviour
{
    private GameObject _door;

    private Vector3 _closedDoorPosition = Vector3.zero;
    private Vector3 _openDoorPosition = Vector3.zero;

    [SerializeField] private bool isDoorOpen = true;

    void Start()
    {
        _door = GameObject.Find("Door");

        _closedDoorPosition = new Vector3(29.7000008f, 13.3500004f, 55.0f);
        _openDoorPosition = new Vector3(29.7000008f, 6.1500001f, 55.0f);

        _door.transform.position = _openDoorPosition;
    }

    void Update()
    {
        if (!isDoorOpen && _door.transform.position != _closedDoorPosition)
        {
            _door.transform.position = Vector3.Lerp(_door.transform.position, _closedDoorPosition, Time.deltaTime * 2);
        }
        else if (isDoorOpen && _door.transform.position != _openDoorPosition)
        {
            _door.transform.position = Vector3.Lerp(_door.transform.position, _openDoorPosition, Time.deltaTime * 2);
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Gem_3"))
        {
            isDoorOpen = false;
            Debug.Log("Door closing...");
        }

        if (isDoorOpen && (triggerHit.gameObject.CompareTag("SmallRock1") || triggerHit.gameObject.CompareTag("SmallRock2")))
        {
            isDoorOpen = false;
            Debug.Log("Door closing...");
        }

        if(isDoorOpen && triggerHit.gameObject.CompareTag("MediumRock"))
        {
            isDoorOpen = false;
            Debug.Log("Door closing...");
        }
    }

    private void OnTriggerStay(Collider triggerHit)
    {
        if (!triggerHit.gameObject.CompareTag("Gem_3") && triggerHit.gameObject.CompareTag("SmallRock1") && triggerHit.gameObject.CompareTag("SmallRock2"))
        {
            isDoorOpen = true;
            Debug.Log("Door opening...");
        }
        else if (!triggerHit.gameObject.CompareTag("Gem_3") && triggerHit.gameObject.CompareTag("MediumRock"))
        {
            isDoorOpen = true;
            Debug.Log("Door opening...");
        }
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Gem_3"))
        {
            isDoorOpen = true;
            Debug.Log("Door opening...");
        }
    }
}
