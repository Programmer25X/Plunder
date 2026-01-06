using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DCC_Coin : MonoBehaviour
{
    private DCC_CompassAndCoin coinGUIScript;
    private int _value = 1;

    private void Awake()
    {
        coinGUIScript = GameObject.Find("GUI").GetComponent<DCC_CompassAndCoin>();
    }
    private void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true; 
    }
    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            coinGUIScript.IncreaseCoinCount();
            gameObject.SetActive(false);
        }
    }
}
