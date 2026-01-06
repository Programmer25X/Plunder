using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DCC_Coin : MonoBehaviour
{
    private int _value = 1;

    private void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true; 
    }
    private void OnTriggerEnter(Collider triggerHit)
    {
        if (triggerHit.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
