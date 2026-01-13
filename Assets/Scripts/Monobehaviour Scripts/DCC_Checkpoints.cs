using UnityEngine;

public class DCC_Checkpoints : MonoBehaviour
{
    [SerializeField] private bool _isFinalCheckpoint = false;
    
    private DCC_LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = GameObject.Find("GUI").GetComponent<DCC_LevelManager>();
    }
    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            if (!_isFinalCheckpoint)
            {
                triggerHit.SendMessage("SetCheckpointLocation", transform.position, SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                _levelManager.LoadReplay(); 
            }
        }
    }

}
