using UnityEngine;

public class DCC_ChildToParent : MonoBehaviour
{
    [Header("Parent Objects Properties")]
    [SerializeField][Tooltip("Tag of the Parent Object")] private string _parentTag = "Moving";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.autoSyncTransforms = true;
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag(_parentTag))
        {
            transform.parent = triggerHit.gameObject.transform;
            Debug.Log("Attached to parent object");
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag(_parentTag))
        {
            transform.parent = null;
            Debug.Log("Unattached to parent object");
        }
    }

}
