using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class DCC_Coin : MonoBehaviour
{
    public CoinData coinData; 

    private DCC_CompassAndCoin _coinGUIScript;

    private void Awake()
    {
        _coinGUIScript = GameObject.Find("GUI").GetComponent<DCC_CompassAndCoin>();
    }
    private void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true; 
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
