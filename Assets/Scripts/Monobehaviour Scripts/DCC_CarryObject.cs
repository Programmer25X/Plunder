using UnityEngine;

public class DCC_CarryObject : MonoBehaviour
{
    [SerializeField] private GameObject _trigger;

    private float _interactDistance = 2.0f;
    private Transform _handTransform;
    private Transform _pcTransform;

    private bool _isCarryingObject = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _pcTransform = GameObject.FindWithTag("Player").transform;
        _handTransform = GameObject.Find("Hand").transform;
        _isCarryingObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_isCarryingObject && Vector3.Distance(transform.position, _pcTransform.position) < _interactDistance)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;

                transform.position = _handTransform.position;
                transform.parent = _handTransform;
                _isCarryingObject = true;
                _trigger.SetActive(false);

                if(gameObject.GetComponent<DCC_Prompt_Message>().isActiveAndEnabled)
                {
                    gameObject.GetComponent<DCC_Prompt_Message>().enabled = false;
                }

            }
            else
            {
                _isCarryingObject = false;
                transform.parent = null;
                _trigger.SetActive(true);

                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;

                if(!gameObject.GetComponent<DCC_Prompt_Message>().isActiveAndEnabled)
                {
                    gameObject.GetComponent<DCC_Prompt_Message>().enabled = true;
                }
            }
        }
    }
}
