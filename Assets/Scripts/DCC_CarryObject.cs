using UnityEngine;

public class DCC_CarryObject : MonoBehaviour
{
    [Header("Carry Objects Properties")]
    [SerializeField][Tooltip("Maximum distance the PC can grab the object. ")][Range(0.1f, 100.0f)] private float grabDistance = 2.0f;

    private Transform pcTransform;

    private bool isCarryingObject = false;
    private bool hasRigidbody = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCarryingObject = false;
        hasRigidbody = GetComponent<Rigidbody>() ? true : false;
        pcTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, pcTransform.position) < grabDistance)
            {
                if (!isCarryingObject)
                {
                    GetComponent<Rigidbody>().useGravity = false;
                    GetComponent<Rigidbody>().isKinematic = true;

                    transform.SetLocalPositionAndRotation(pcTransform.position + pcTransform.TransformDirection(1f, 1f, 1.5f), pcTransform.rotation);
                    transform.parent = pcTransform;
                    isCarryingObject = true;
                }
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
}
