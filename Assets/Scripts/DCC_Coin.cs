using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(AudioSource))]
public class DCC_Coin : MonoBehaviour
{
    private DCC_CompassAndCoin _coinGUIScript;

    [SerializeField] private AudioClip _clip;

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
            AudioSource.PlayClipAtPoint(_clip, gameObject.transform.position); 
            _coinGUIScript.IncreaseCoinCount();
            gameObject.SetActive(false);
        }
    }
}
