using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class DCC_CoinBehaviour : MonoBehaviour
{
    public CoinData coinData; 

    private DCC_CompassAndCoin _coinGUIScript;
    private Vector3 _initalPosition;

    [SerializeField] private bool _isGUICoin = false;
    private void Awake()
    {
        _coinGUIScript = GameObject.Find("GUI").GetComponent<DCC_CompassAndCoin>();
    }

    private void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
        _initalPosition = transform.position;
    }
    private void Update()
    {
        if(!_isGUICoin)
        {
            transform.position = new Vector3(transform.position.x, _initalPosition.y + (coinData.GetMagnitude() * Mathf.Sin(Time.time * coinData.GetFrequency())), transform.position.z);
            transform.Rotate(0, 90.0f * Time.deltaTime * coinData.GetRotationSpeedMultiplier(), 0);
        }
        else
        {
            transform.Rotate(0, 90.0f * Time.deltaTime * coinData.GetRotationSpeedMultiplier(), 0);
        }
    }

    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinData.GetAudioClip(), gameObject.transform.position); 
            _coinGUIScript.IncreaseCoinCount();
            gameObject.SetActive(false);
        }
    }
}
