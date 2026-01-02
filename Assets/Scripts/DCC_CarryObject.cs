using UnityEngine;

public class DCC_CarryObject : MonoBehaviour
{
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
            }
            else
            {
                _isCarryingObject = false;
                transform.parent = null;

                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
