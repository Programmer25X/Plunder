using UnityEngine;

public class DCC_Weighing_Scale : MonoBehaviour
{
    private GameObject _door;

    private Vector3 _closedDoorPosition;
    private Vector3 _openDoorPosition;

    private bool _isDoorOpen = true;
    private bool _isGemOnPedestal = true;
    private bool _isSmallRockOneOnPedestal = false;
    private bool _isSmallRockTwoOnPedestal = false;
    private bool _isMediumRockOnPedestal = false;
    private bool _isLargeRockOnPedestal = false;

    void Start()
    {
        _door = GameObject.Find("Door");

        _closedDoorPosition = new Vector3(_door.transform.position.x, _door.transform.position.y + 14f, _door.transform.position.z);
        _openDoorPosition = new Vector3(_door.transform.position.x, _door.transform.position.y, _door.transform.position.z);

        _door.transform.position = _openDoorPosition;
    }

    void Update()
    {
        if (_isGemOnPedestal && !_isSmallRockOneOnPedestal && !_isSmallRockTwoOnPedestal && !_isMediumRockOnPedestal && !_isLargeRockOnPedestal)
        {
            _isDoorOpen = true;
        }
        else if(_isSmallRockOneOnPedestal && _isSmallRockTwoOnPedestal && !_isMediumRockOnPedestal && !_isGemOnPedestal)
        {
            _isDoorOpen = true;
        }
        else if(_isMediumRockOnPedestal && !_isSmallRockOneOnPedestal && !_isSmallRockTwoOnPedestal && !_isGemOnPedestal)
        {
            _isDoorOpen = true;
        }
        else if(_isLargeRockOnPedestal)
        {
            _isDoorOpen = false;
        }
        else
        {
            _isDoorOpen = false; 
        }


        if (!_isDoorOpen && _door.transform.position != _closedDoorPosition)
        {
            _door.transform.position = Vector3.Lerp(_door.transform.position, _closedDoorPosition, Time.deltaTime * 2);
        }
        else if (_isDoorOpen && _door.transform.position != _openDoorPosition)
        {
            _door.transform.position = Vector3.Lerp(_door.transform.position, _openDoorPosition, Time.deltaTime * 2);
        }

    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Gem_3"))
        {
            _isGemOnPedestal = true;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock1"))
        {
            _isSmallRockOneOnPedestal = true;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock2"))
        {
            _isSmallRockTwoOnPedestal = true;
        }

        if (triggerHit.gameObject.CompareTag("MediumRock"))
        {
            _isMediumRockOnPedestal = true;
        }

        if(triggerHit.gameObject.CompareTag("LargeRock"))
        {
            _isLargeRockOnPedestal= true; 
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Gem_3"))
        {
            _isGemOnPedestal = false;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock1"))
        {
            _isSmallRockOneOnPedestal = false;
        }

        if (triggerHit.gameObject.CompareTag("SmallRock2"))
        {
            _isSmallRockTwoOnPedestal = false;
        }

        if (triggerHit.gameObject.CompareTag("MediumRock"))
        {
            _isMediumRockOnPedestal = false;
        }

        if(triggerHit.gameObject.CompareTag("LargeRock"))
        {
            _isLargeRockOnPedestal = false;
        }
    }
}
