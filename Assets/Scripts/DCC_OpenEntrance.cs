using UnityEngine;

public class DCC_OpenEntrance : MonoBehaviour
{
    [SerializeField] private bool _isBlueGemPlaced = false;
    [SerializeField] private bool _isYellowGemPlaced = false;
    [SerializeField] private bool _isRedGemPlaced = false;

    private GameObject _secretEntrance;

    private Vector3 _lockedPosition = Vector3.zero;
    private Vector3 _unlockedPosition = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _secretEntrance = GameObject.Find("Secret Entrance");

        _lockedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _unlockedPosition = new Vector3(143.5f, 9.5f, 55f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isBlueGemPlaced && _isRedGemPlaced && _isYellowGemPlaced)
        {
            _secretEntrance.transform.position = Vector3.Lerp(_secretEntrance.transform.position, _unlockedPosition, Time.deltaTime * 0.5f);
        }
        else
        {
            _secretEntrance.transform.position = Vector3.Lerp(_secretEntrance.transform.position, _lockedPosition, Time.deltaTime * 0.5f);

        }
    }

    public void SetIsBlueGemPlaced(bool isPlaced)
    {
        _isBlueGemPlaced = isPlaced;
    }

    public void SetIsYellowGemPlaced(bool isPlaced)
    {
        _isYellowGemPlaced = isPlaced;
    }

    public void SetIsRedGemPlaced(bool isPlaced)
    {
        _isRedGemPlaced = isPlaced;
    }
}
