using UnityEngine;

public class DCC_CaveEntrance : MonoBehaviour
{
    private GameObject _playerCharacter;
    private bool _canTeleport = false; 

    [SerializeField] private Transform _spawnPosition;

    private void Update()
    {
        if(_canTeleport)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _canTeleport = false;
                _playerCharacter.SetActive(false);
                _playerCharacter.transform.position = _spawnPosition.transform.position;
                _playerCharacter.SetActive(true);   
            }
        }
    }

    private void Start()
    {
        _playerCharacter = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            _canTeleport = true; 
            Debug.Log("Cave Entrance Near");
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if(triggerHit.gameObject.CompareTag("Player"))
        {
            _canTeleport = false; 
        }
    }

}
