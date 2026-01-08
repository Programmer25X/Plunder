using UnityEngine;

public class DCC_HintMoveBehaviour : MonoBehaviour
{
    public HintData hintData;

    private Vector3 _initalPosition;

    private void Start()
    {
        _initalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, _initalPosition.y + (hintData.GetMagnitude() * Mathf.Sin(Time.time * hintData.GetFrequency())), transform.position.z);
        transform.Rotate(0, 90.0f * Time.deltaTime * hintData.GetRotationSpeedMultiplier(), 0);
    }
}
