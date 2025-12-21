using UnityEngine;

public class DCC_Weighing_Scale : MonoBehaviour
{
    private GameObject _door;

    private Vector3 _closedDoorPosition = Vector3.zero;
    private Vector3 _openDoorPosition = Vector3.zero;

    [SerializeField] private bool isDoorOpen = true;

    private bool isGemOnPedestal = true;
    private bool isSmallRockOneOnPedestal = false;
    private bool isSmallRockTwoOnPedestal = false;
    private bool isMediumRockOnPedestal = false;

    void Start()
    {
        _door = GameObject.Find("Door");

        _closedDoorPosition = new Vector3(_door.transform.position.x, _door.transform.position.y + 14f, _door.transform.position.z);
        _openDoorPosition = new Vector3(_door.transform.position.x, _door.transform.position.y, _door.transform.position.z);

        _door.transform.position = _openDoorPosition;
    }

    void Update()
    {
        if (isGemOnPedestal ^ (isSmallRockOneOnPedestal && isSmallRockTwoOnPedestal) ^ isMediumRockOnPedestal)
        {
            isDoorOpen = true;
        }
        else
        {
            isDoorOpen = false;
        }


        if (!isDoorOpen && _door.transform.position != _closedDoorPosition)
        {
            _door.transform.position = Vector3.Lerp(_door.transform.position, _closedDoorPosition, Time.deltaTime * 2);
        }
        else if (isDoorOpen && _door.transform.position != _openDoorPosition)
        {
            _door.transform.position = Vector3.Lerp(_door.transform.position, _openDoorPosition, Time.deltaTime * 2);
        }

    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Gem_3"))
        {
            isGemOnPedestal = true;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock1"))
        {
            isSmallRockOneOnPedestal = true;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock2"))
        {
            isSmallRockTwoOnPedestal = true;
        }

        if (triggerHit.gameObject.CompareTag("MediumRock"))
        {
            isMediumRockOnPedestal = true;
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Gem_3"))
        {
            isGemOnPedestal = false;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock1"))
        {
            isSmallRockOneOnPedestal = false;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock2"))
        {
            isSmallRockTwoOnPedestal = false;
        }

        if (triggerHit.gameObject.CompareTag("MediumRock"))
        {
            isMediumRockOnPedestal = false;
        }
    }
}
