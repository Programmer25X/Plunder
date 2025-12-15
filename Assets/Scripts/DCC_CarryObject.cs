using UnityEngine;

public class DCC_CarryObject : MonoBehaviour
{
    [SerializeField][Tooltip("Activation Distance")] float interactDistance = 10.0f;
    private Transform pcTransform;

    private bool isCarryingObject = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCarryingObject = false;
        pcTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isCarryingObject && Vector3.Distance(transform.position, pcTransform.position) < interactDistance)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;

                transform.SetLocalPositionAndRotation(pcTransform.position + new Vector3(0, 0, 1.0f) + pcTransform.TransformDirection(0.5f, 0.5f, 0.5f), pcTransform.rotation);
                transform.parent = pcTransform;
                isCarryingObject = true;
            }
            else
            {
                isCarryingObject = false;
                transform.parent = null;

                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            if (!isCarryingObject)
            {
                SendMessage("IsHittingInteractable", true, SendMessageOptions.RequireReceiver);
            }
        }
    }

    private void OnTriggerStay(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            if (!isCarryingObject)
            {
                SendMessage("IsHittingInteractable", true, SendMessageOptions.RequireReceiver);
            }
        }
    }

    private void OnTriggerExit(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            SendMessage("IsHittingInteractable", false, SendMessageOptions.RequireReceiver);
        }
    }
}
