using UnityEngine;

public class DCC_CaveEntrance : MonoBehaviour
{
    private GameObject _playerCharacter;

    [SerializeField] private Transform _spawnPosition;

    private void Start()
    {
        _playerCharacter = GameObject.FindWithTag("Player"); 
    }
    private void OnTriggerEnter(Collider triggerHit)
    {
        if(triggerHit.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _playerCharacter.transform.position = _spawnPosition.transform.position;
            }
        }
    }
}
